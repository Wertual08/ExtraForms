using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraForms
{
    public partial class BitmapForm : Form
    {
        private bool MouseHold;
        private PointF MousePt;
        private float OffsetX, OffsetY, BaseZoom, Zoom;
        public Bitmap Texture { get; private set; }

        public BitmapForm(Bitmap bitmap = null)
        {
            InitializeComponent();

            PreviewPanel.MouseWheel += PreviewPanel_MouseWheel;

            Texture = bitmap;

            MouseHold = false;
            MousePt = new PointF();

            OffsetX = PreviewPanel.ClientSize.Width / 2;
            OffsetY = PreviewPanel.ClientSize.Height / 2;
            Zoom = 1.0f;
            BaseZoom = 1.0f;

            if (Texture != null)
            {
                BaseZoom = Math.Min((float)PreviewPanel.ClientSize.Width / Texture.Width,
                    (float)PreviewPanel.ClientSize.Height / Texture.Height);

                PropertiesTextBox.Text = "[" + Texture.PixelFormat +
                    "] " + Texture.Width + " x " + Texture.Height;
                ExportButton.Enabled = true;
            }
            else ExportButton.Enabled = false;

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty |
                BindingFlags.Instance | BindingFlags.NonPublic, null, PreviewPanel,
                new object[] { true });

            RepairOffset();
            PreviewPanel.Invalidate();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ImportFileDialog.ShowDialog() != DialogResult.OK) return;
                Texture = new Bitmap(ImportFileDialog.FileName);

                if (Texture != null)
                {
                    BaseZoom = Math.Min((float)PreviewPanel.ClientSize.Width / Texture.Width,
                        (float)PreviewPanel.ClientSize.Height / Texture.Height);

                    PropertiesTextBox.Text = "[" + Texture.PixelFormat +
                        "] " + Texture.Width + " x " + Texture.Height;
                    ExportButton.Enabled = true;
                }
                else ExportButton.Enabled = false;

                RepairOffset();
                PreviewPanel.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: Can not import texture.");
            }
        }
        private void ExportButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ExportFileDialog.ShowDialog() != DialogResult.OK) return;
                Texture.Save(ExportFileDialog.FileName, ImageFormat.Png);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: Can not export texture.");
            }
        }

        private void PreviewPanel_Paint(object sender, PaintEventArgs e)
        {
            if (Texture == null) return;

            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                SizeF ClientSize = ((Panel)sender).ClientSize;

                e.Graphics.TranslateTransform(OffsetX, OffsetY);
                e.Graphics.ScaleTransform(BaseZoom * Zoom, BaseZoom * Zoom);

                RectangleF Imgbox = new RectangleF(-Texture.Width / 2.0f,
                    -Texture.Height / 2.0f, Texture.Width, Texture.Height);
                if (Texture != null) e.Graphics.DrawImage(Texture, Imgbox);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: Can not render texture.");
            }
        }
        private void RepairOffset()
        {
            if (Texture == null) return;
            if (OffsetX > Texture.Width / 2 * BaseZoom * Zoom) OffsetX = Texture.Width / 2 * BaseZoom * Zoom;
            if (OffsetY > Texture.Height / 2 * BaseZoom * Zoom) OffsetY = Texture.Height / 2 * BaseZoom * Zoom;
            if (OffsetX + Texture.Width / 2 * BaseZoom * Zoom < PreviewPanel.ClientSize.Width)
                OffsetX = PreviewPanel.ClientSize.Width - Texture.Width / 2 * BaseZoom * Zoom;
            if (OffsetY + Texture.Height / 2 * BaseZoom * Zoom < PreviewPanel.ClientSize.Height)
                OffsetY = PreviewPanel.ClientSize.Height - Texture.Height / 2 * BaseZoom * Zoom;

            if (Texture.Width * BaseZoom * Zoom <= PreviewPanel.ClientSize.Width)
                OffsetX = PreviewPanel.ClientSize.Width / 2;
            if (Texture.Height * BaseZoom * Zoom <= PreviewPanel.ClientSize.Height)
                OffsetY = PreviewPanel.ClientSize.Height / 2;
        }
        private void PreviewPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            float OldZoom = Zoom;
            if (e.Delta > 0) Zoom *= 2.0f;
            if (e.Delta < 0) Zoom /= 2.0f;

            if (BaseZoom * Zoom < 0.01f) Zoom = OldZoom;
            if (BaseZoom * Zoom > 100.0f) Zoom = OldZoom;

            RepairOffset();

            PreviewPanel.Invalidate();
        }
        private void PreviewPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MousePt = e.Location;
            MouseHold = true;
        }

        private void TextureForm_Resize(object sender, EventArgs e)
        {
            if (Texture != null)
                BaseZoom = Math.Min((float)PreviewPanel.ClientSize.Width / Texture.Width,
                    (float)PreviewPanel.ClientSize.Height / Texture.Height);

            RepairOffset();
            PreviewPanel.Invalidate();
        }

        private void PreviewPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!MouseHold) return;
            
            OffsetX += e.Location.X - MousePt.X;
            OffsetY += e.Location.Y - MousePt.Y;

            RepairOffset();

            MousePt = e.Location;
            PreviewPanel.Invalidate();
        }
        private void PreviewPanel_MouseUp(object sender, MouseEventArgs e)
        {
            MouseHold = false;
            MousePt = new PointF();
        }
    }
}
