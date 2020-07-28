using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ExtraForms
{
    public class BitmapBox : UserControl
    {
        private string PropertiesText = null;
        private Point MousePt;
        private float OffsetX, OffsetY, BaseZoom, Zoom;
        private PointF AdjustOffset()
        {
            return new PointF(
                OffsetX + (ClientSize.Width - BitmapStorage.Width * BaseZoom) / 2f,
                OffsetY + (ClientSize.Height - BitmapStorage.Height * BaseZoom) / 2f);
        }

        private Bitmap BitmapStorage = null;

        private void RepairOffset()
        {
            if (BitmapStorage == null) return;
            var o = AdjustOffset();
            float sw = ClientSize.Width;
            float sh = ClientSize.Height;
            float bw = BitmapStorage.Width * BaseZoom * Zoom;
            float bh = BitmapStorage.Height * BaseZoom * Zoom;
            if (o.X + bw < 0) OffsetX = -bw - (ClientSize.Width - BitmapStorage.Width * BaseZoom) / 2f;
            if (o.X > sw) OffsetX = sw - (ClientSize.Width - BitmapStorage.Width * BaseZoom) / 2f;
            if (o.Y + bh < 0) OffsetY = -bh - (ClientSize.Height - BitmapStorage.Height * BaseZoom) / 2f;
            if (o.Y > sh) OffsetY = sh - (ClientSize.Height - BitmapStorage.Height * BaseZoom) / 2f;
        }

        public Bitmap Bitmap
        {
            get
            {
                return BitmapStorage;
            }
            set
            {
                BitmapStorage = value;
                ResetLocation();
            }
        }
        public bool ShowProperties
        {
            get
            {
                return PropertiesText != null;
            }
            set
            {
                if (value)
                {
                    if (BitmapStorage != null) PropertiesText = "[" + BitmapStorage.PixelFormat +
                        "] " + BitmapStorage.Width + " x " + BitmapStorage.Height;
                    else PropertiesText = "";
                }
                else PropertiesText = null;
                Invalidate();
            }
        }
        public float ZoomStep { get; set; } = 1.1f;
        public float ZoomLimit { get; set; } = 100f;

        public void PerformZoom(float x, float y, float z)
        {
            var o = AdjustOffset();
            float ox = OffsetX;
            float oy = OffsetY;
            float oz = Zoom;
            OffsetX -= (x - o.X) * (z - 1f);
            OffsetY -= (y - o.Y) * (z - 1f);
            Zoom *= z;
            if (Zoom < 1f / ZoomLimit || Zoom > ZoomLimit)
            {
                OffsetX = ox;
                OffsetY = oy;
                Zoom = oz;
            }

            RepairOffset();
            Invalidate();
        }
        public void ResetLocation()
        {
            if (BitmapStorage == null) return;
            BaseZoom = Math.Min((float)ClientSize.Width / BitmapStorage.Width,
                        (float)ClientSize.Height / BitmapStorage.Height);

            OffsetX = 0f;
            OffsetY = 0f;
            Zoom = 1f;
            RepairOffset();

            if (PropertiesText != null) PropertiesText = "[" + BitmapStorage.PixelFormat +
                "] " + BitmapStorage.Width + " x " + BitmapStorage.Height;

            Invalidate();
        }

        public BitmapBox()
        {
            DoubleBuffered = true;
        }

        protected override void OnResize(EventArgs e)
        {
            if (BitmapStorage != null)
                BaseZoom = Math.Min((float)ClientSize.Width / BitmapStorage.Width,
                    (float)ClientSize.Height / BitmapStorage.Height);
            
            RepairOffset();
            base.OnResize(e);
            Invalidate();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (BitmapStorage == null) return;
            if (Zoom == 0) return;

            float cw = ClientSize.Width;
            float ch = ClientSize.Height;

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            // Bitmap rendering //
            var o = AdjustOffset();
            float x1 = Math.Max(0f, o.X);
            float y1 = Math.Max(0f, o.Y);
            float x2 = Math.Min(cw, o.X + BitmapStorage.Width * BaseZoom * Zoom);
            float y2 = Math.Min(ch, o.Y + BitmapStorage.Height * BaseZoom * Zoom);

            float x = x1;
            float y = y1;
            float w = x2 - x1;
            float h = y2 - y1;

            float srcx = (x - o.X) / (BaseZoom * Zoom);
            float srcy = (y - o.Y) / (BaseZoom * Zoom);
            float srcw = w / (BaseZoom * Zoom);
            float srch = h / (BaseZoom * Zoom);

            RectangleF Imgbox = new RectangleF(x, y, w, h);
            RectangleF Srcbox = new RectangleF(srcx, srcy, srcw, srch);

            if (Imgbox.Width > 0 && Imgbox.Height > 0 && Srcbox.Width > 0 && Srcbox.Height > 0)
                e.Graphics.DrawImage(BitmapStorage, Imgbox, Srcbox, GraphicsUnit.Pixel);
            // //////////////// //

            // Properties rendering //
            if (PropertiesText != null)
            {
                using (var brush = new SolidBrush(Color.FromArgb(BackColor.ToArgb() ^ 0xffffff)))
                {
                    e.Graphics.DrawString(PropertiesText, Font,
                        brush, 0, ch - 2 - Font.Height);
                }
            }
            // //////////////////// //

            base.OnPaint(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0) PerformZoom(e.Location.X, e.Location.Y, ZoomStep);
            if (e.Delta < 0) PerformZoom(e.Location.X, e.Location.Y, 1.0f / ZoomStep);
            base.OnMouseWheel(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            MousePt = e.Location;
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                OffsetX += e.Location.X - MousePt.X;
                OffsetY += e.Location.Y - MousePt.Y;

                RepairOffset();

                MousePt = e.Location;
                Invalidate();
            }
            base.OnMouseMove(e);
        }
    }
}
