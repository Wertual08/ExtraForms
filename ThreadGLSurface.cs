using ExtraForms.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraForms
{
    [DefaultEvent("GLPaint")]
    public class ThreadGLSurface : Control
    {
        private struct ThreadArgs
        {
            public IntPtr HWND;
            public ThreadArgs(IntPtr hwnd)
            {
                HWND = hwnd;
            }
        }

        private static void GLInit(IntPtr hwnd, out IntPtr hdc, out IntPtr hglrc)
        {
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

            hdc = gdi.GetDC(hwnd);
            if (hdc == IntPtr.Zero) throw new Exception("ThreadGLSurface error: Failed to get device context.");
            int iPixelFormat = gdi.ChoosePixelFormat(hdc, out pfd);
            if (!gdi.SetPixelFormat(hdc, iPixelFormat, out pfd)) throw new Exception("ThreadGLSurface error: Failed to set pixel format.");
            hglrc = wgl.CreateContext(hdc);
            if (hglrc == IntPtr.Zero) throw new Exception("ThreadGLSurface error: Failed to create OpenGL device context.");
            if (!wgl.MakeCurrent(hdc, hglrc)) throw new Exception("ThreadGLSurface error: Failed to make device context current.");
        }
        private static void GLDispose(IntPtr hwnd, IntPtr hdc, IntPtr hglrc)
        {
            if (hwnd != IntPtr.Zero && hdc != IntPtr.Zero)
            {
                if (hglrc != IntPtr.Zero)
                {
                    wgl.MakeCurrent(hdc, IntPtr.Zero);
                    wgl.DeleteContext(hglrc);
                }
                gdi.ReleaseDC(hwnd, hdc);
            }
        }
        private void Worker(object args)
        {
            var Args = (ThreadArgs)args;
            var HWND = Args.HWND;
            var HDC = IntPtr.Zero;
            var HGLRC = IntPtr.Zero;

            try
            {
                GLInit(HWND, out HDC, out HGLRC);

                gl.Enable(GL.BLEND);
                gl.BlendFunc(GL.SRC_ALPHA, GL.ONE_MINUS_SRC_ALPHA);
                gl.DepthMask(GL.FALSE);
                gl.MatrixMode(GL.PROJECTION);

                gl.Viewport(0, 0, ClientSize.Width, ClientSize.Height);
                gl.LoadIdentity();
                gl.Ortho(-SurfaceSize.Width / 2f, SurfaceSize.Width / 2f,
                    -SurfaceSize.Height / 2f, SurfaceSize.Height / 2f, 0f, 1f);

                GLStart?.Invoke(this, EventArgs.Empty);

                var FrameTimer = new Stopwatch();
                while (RendererRunning)
                {
                    if (FPS <= 0) Thread.Sleep(100);
                    else
                    {
                        var delay = 1000 / FPS - (int)FrameTimer.ElapsedMilliseconds;
                        if (delay > 0) Thread.Sleep(delay);
                        FrameTimer.Restart();

                        lock (ActionRequests)
                            while (ActionRequests.Count > 0)
                                ActionRequests.Dequeue().Invoke();

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
            }
            finally
            {
                GLStop?.Invoke(this, EventArgs.Empty);

                GLDispose(HWND, HDC, HGLRC);
            }
        }

        private Queue<Action> ActionRequests = new Queue<Action>();
        private bool RendererRunning = false;
        private Thread RendererThread;
        private float GLZoom = 1f;

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
        protected override void OnPaint(PaintEventArgs e)
        {
        }
        protected override void OnInvalidated(InvalidateEventArgs e)
        {
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            GLRequest(() => {
                gl.Viewport(0, 0, ClientSize.Width, ClientSize.Height);
                gl.LoadIdentity();
                gl.Ortho(-SurfaceSize.Width / 2f, SurfaceSize.Width / 2f,
                    -SurfaceSize.Height / 2f, SurfaceSize.Height / 2f, 0f, 1f);
            });
            GLSizeChanged?.Invoke(this, EventArgs.Empty);
            base.OnClientSizeChanged(e);
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            GLMouseWheel?.Invoke(this, new GLMouseEventArgs(
                e.Button, e.Clicks, e.X / GLZoom - SurfaceSize.Width / 2f,
                SurfaceSize.Height / 2f - e.Y / GLZoom, (float)e.Delta /
                SystemInformation.MouseWheelScrollDelta));
            base.OnMouseWheel(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            GLMouseDown?.Invoke(this, new GLMouseEventArgs(
                e.Button, e.Clicks, e.X / GLZoom - SurfaceSize.Width / 2f,
                SurfaceSize.Height / 2f - e.Y / GLZoom, (float)e.Delta / 
                SystemInformation.MouseWheelScrollDelta));
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            GLMouseMove?.Invoke(this, new GLMouseEventArgs(
                e.Button, e.Clicks, e.X / GLZoom - SurfaceSize.Width / 2f,
                SurfaceSize.Height / 2f - e.Y / GLZoom, (float)e.Delta /
                SystemInformation.MouseWheelScrollDelta));
            base.OnMouseMove(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            GLMouseUp?.Invoke(this, new GLMouseEventArgs(
                e.Button, e.Clicks, e.X / GLZoom - SurfaceSize.Width / 2f,
                SurfaceSize.Height / 2f - e.Y / GLZoom, (float)e.Delta /
                SystemInformation.MouseWheelScrollDelta));
            base.OnMouseUp(e);
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();

            if (RendererThread.IsAlive)
            {
                RendererRunning = false;
                if (!RendererThread.Join(1000))
                    RendererThread.Abort();
            }

            RendererRunning = true;
            RendererThread.Start(new ThreadArgs(Handle));
        }
        protected override void DestroyHandle()
        {
            if (RendererThread.IsAlive)
            {
                RendererRunning = false;
                if (!RendererThread.Join(1000))
                    RendererThread.Abort();
            }

            base.DestroyHandle();
        }

        public ThreadGLSurface()
        {
            RendererThread = new Thread(Worker);
            RendererThread.IsBackground = true;
        }
        protected override void Dispose(bool disposing)
        {
            if (RendererThread.IsAlive)
            {
                RendererRunning = false;
                if (!RendererThread.Join(1000))
                    RendererThread.Abort();
            }
            base.Dispose(disposing);
        }

        public int FPS { get; set; } = 30;
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
                GLRequest(() => {
                    gl.LoadIdentity();
                    gl.Ortho(-SurfaceSize.Width / 2f, SurfaceSize.Width / 2f,
                        -SurfaceSize.Height / 2f, SurfaceSize.Height / 2f, 0f, 1f);
                });
                GLSizeChanged?.Invoke(this, EventArgs.Empty);
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

        public void GLRequest(Action action)
        {
            if (!RendererRunning) return;
            lock (ActionRequests) ActionRequests.Enqueue(action);
        }
        public void GLSyncRequest(Action action)
        {
            if (!RendererRunning) return;

            lock (ActionRequests) ActionRequests.Enqueue(action);
            bool waiting = true;
            while (waiting)
            {
                if (FPS <= 0) Thread.Sleep(100);
                else Thread.Sleep(1000 / FPS);
                lock (ActionRequests) if (ActionRequests.Count < 1) waiting = false;
            }
        }
    }
}
