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
using System.Runtime.InteropServices;
using ExtraForms.OpenGL;

namespace ExtraForms
{
    [DefaultEvent("Paint")]
    public class OpenGLSurface : Control
    {
        private static IntPtr CurrentContext = IntPtr.Zero;
        private float GLZoom = 1f;
        private IntPtr HDC = IntPtr.Zero;
        private IntPtr HGLRC = IntPtr.Zero;

        public bool NoClear { get; set; } = false;
        public SizeF SurfaceSize
        {
            get 
            { 
                return new SizeF(ClientSize.Width / GLZoom, ClientSize.Height / GLZoom); 
            }
        }
        public float Zoom
        {
            get { return GLZoom; }
            set
            {
                if (GLZoom == value) return;
                GLZoom = value;
                if (MakeCurrent())
                {
                    gl.LoadIdentity();
                    gl.Ortho(-SurfaceSize.Width / 2f, SurfaceSize.Width / 2f,
                        -SurfaceSize.Height / 2f, SurfaceSize.Height / 2f, 0f, 1f);
                }
            }
        }

        public event EventHandler GLStart;
        public event EventHandler GLPaint;
        public event EventHandler GLStop;
        public event EventHandler GLSizeChanged;
        public event GLMouseEventHandler GLMouseWheel;
        public event GLMouseEventHandler GLMouseDown;
        public event GLMouseEventHandler GLMouseMove;
        public event GLMouseEventHandler GLMouseUp;

        public bool MakeCurrent()
        {
            if (Handle == IntPtr.Zero) CreateHandle();
            if (HDC == IntPtr.Zero) return false;
            if (HGLRC == CurrentContext) return true;
            CurrentContext = HGLRC;
            return wgl.MakeCurrent(HDC, HGLRC);
        }
        public static void ResetCurrent()
        {
            wgl.MakeCurrent(IntPtr.Zero, IntPtr.Zero);
            CurrentContext = IntPtr.Zero;
        }
        public void GLRequest(Action action)
        {
            if (MakeCurrent()) action();
        }
        public PointF AdjustMouse(PointF pos)
        {
            return new PointF(pos.X / GLZoom - SurfaceSize.Width / 2f,
                SurfaceSize.Height / 2f - pos.Y / GLZoom);
        }
        
        public OpenGLSurface()
        {
        }
        protected override void OnClientSizeChanged(EventArgs e)
        {
            if (MakeCurrent())
            {
                gl.Viewport(0, 0, ClientSize.Width, ClientSize.Height);
                gl.LoadIdentity();
                gl.Ortho(-SurfaceSize.Width / 2f, SurfaceSize.Width / 2f,
                    -SurfaceSize.Height / 2f, SurfaceSize.Height / 2f, 0f, 1f);
                GLSizeChanged?.Invoke(this, EventArgs.Empty);
            }
            base.OnClientSizeChanged(e);
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (MakeCurrent()) GLMouseWheel?.Invoke(this, new GLMouseEventArgs(
                e.Button, e.Clicks, e.X / GLZoom - SurfaceSize.Width / 2f,
                SurfaceSize.Height / 2f - e.Y / GLZoom, (float)e.Delta /
                SystemInformation.MouseWheelScrollDelta));
            base.OnMouseWheel(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (MakeCurrent()) GLMouseDown?.Invoke(this, new GLMouseEventArgs(
                e.Button, e.Clicks, e.X / GLZoom - SurfaceSize.Width / 2f,
                SurfaceSize.Height / 2f - e.Y / GLZoom, (float)e.Delta /
                SystemInformation.MouseWheelScrollDelta));
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (MakeCurrent()) GLMouseMove?.Invoke(this, new GLMouseEventArgs(
                e.Button, e.Clicks, e.X / GLZoom - SurfaceSize.Width / 2f,
                SurfaceSize.Height / 2f - e.Y / GLZoom, (float)e.Delta /
                SystemInformation.MouseWheelScrollDelta));
            base.OnMouseMove(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (MakeCurrent()) GLMouseUp?.Invoke(this, new GLMouseEventArgs(
                e.Button, e.Clicks, e.X / GLZoom - SurfaceSize.Width / 2f,
                SurfaceSize.Height / 2f - e.Y / GLZoom, (float)e.Delta /
                SystemInformation.MouseWheelScrollDelta));
            base.OnMouseUp(e);
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            gdi.PIXELFORMATDESCRIPTOR pfd = new gdi.PIXELFORMATDESCRIPTOR();
            pfd.nSize = (ushort)Marshal.SizeOf(pfd);
            pfd.nVersion = 1;
            pfd.dwFlags = gdi.PFD_DRAW_TO_WINDOW | gdi.PFD_SUPPORT_OPENGL | gdi.PFD_DOUBLEBUFFER;
            pfd.iPixelType = gdi.PFD_TYPE_RGBA;
            pfd.cColorBits = 32;
            pfd.cRedBits = 0;
            pfd.cRedShift = 0;
            pfd.cGreenBits = 0;
            pfd.cGreenShift = 0;
            pfd.cBlueBits = 0;
            pfd.cBlueShift = 0;
            pfd.cAlphaBits = 0;
            pfd.cAlphaShift = 0;
            pfd.cAccumBits = 0;
            pfd.cAccumRedBits = 0;
            pfd.cAccumGreenBits = 0;
            pfd.cAccumBlueBits = 0;
            pfd.cAccumAlphaBits = 0;
            pfd.cDepthBits = 24;
            pfd.cStencilBits = 8;
            pfd.cAuxBuffers = 0;
            pfd.iLayerType = 0;
            pfd.bReserved = 0;
            pfd.dwLayerMask = 0;
            pfd.dwVisibleMask = 0;
            pfd.dwDamageMask = 0;
            
            HDC = gdi.GetDC(Handle);
            if (HDC == IntPtr.Zero) throw new Exception("OpenGLSurface error: Failed to get device context.");
            int iPixelFormat = gdi.ChoosePixelFormat(HDC, out pfd);
            if (!gdi.SetPixelFormat(HDC, iPixelFormat, out pfd)) throw new Exception("OpenGLSurface error: Failed to set pixel format.");
            HGLRC = wgl.CreateContext(HDC);
            if (HGLRC == IntPtr.Zero) throw new Exception("OpenGLSurface error: Failed to create OpenGL device context.");
            if (!MakeCurrent()) throw new Exception("OpenGLSurface error: Failed to make device context current.");

            gl.Enable(GL.BLEND);
            gl.BlendFunc(GL.SRC_ALPHA, GL.ONE_MINUS_SRC_ALPHA);
            gl.DepthMask(GL.FALSE);
            gl.MatrixMode(GL.PROJECTION);

            gl.LoadIdentity();
            gl.Ortho(-SurfaceSize.Width / 2f, SurfaceSize.Width / 2f,
                -SurfaceSize.Height / 2f, SurfaceSize.Height / 2f, 0f, 1f);

            GLStart?.Invoke(this, EventArgs.Empty);
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (!IsDisposed)
            {
                if (MakeCurrent()) GLStop?.Invoke(this, EventArgs.Empty);

                if (HGLRC != IntPtr.Zero)
                {
                    wgl.MakeCurrent(HDC, IntPtr.Zero);
                    wgl.DeleteContext(HGLRC);
                    HGLRC = IntPtr.Zero;
                }
                if (HDC != IntPtr.Zero)
                {
                    gdi.ReleaseDC(Handle, HDC);
                    HDC = IntPtr.Zero;
                }
            }

            base.OnHandleDestroyed(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (MakeCurrent())
            {
                if (!NoClear)
                {
                    gl.ClearColor(BackColor.R / 256f, BackColor.G / 256f,
                        BackColor.B / 256f, BackColor.A / 256f);
                    gl.Clear(GL.COLOR_BUFFER_BIT | GL.DEPTH_BUFFER_BIT);
                }
                GLPaint?.Invoke(this, EventArgs.Empty);
                gdi.SwapBuffers(HDC);
            }
        }
        
        protected override void Dispose(bool disposing)
        {
            if (IsDisposed) return;

            if (disposing)
            {
                if (MakeCurrent()) GLStop?.Invoke(this, EventArgs.Empty);

                if (HGLRC != IntPtr.Zero)
                {
                    wgl.MakeCurrent(HDC, IntPtr.Zero);
                    wgl.DeleteContext(HGLRC);
                    HGLRC = IntPtr.Zero;
                }
                if (HDC != IntPtr.Zero)
                {
                    gdi.ReleaseDC(Handle, HDC);
                    HDC = IntPtr.Zero;
                }
            }

            base.Dispose(disposing);
        }
    }
}
