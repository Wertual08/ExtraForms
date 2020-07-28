using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraForms
{
    public class GLMouseEventArgs : EventArgs
    {
        public GLMouseEventArgs(MouseButtons button, int clicks, float x, float y, float delta)
        {
            Button = button;
            Clicks = clicks;
            X = x;
            Y = y;
            Delta = delta;
        }
        public MouseButtons Button { get; }
        public int Clicks { get; }
        public float X { get; }
        public float Y { get; }
        public float Delta { get; }
        public PointF Location { get { return new PointF(X, Y); } }
    }
    public delegate void GLMouseEventHandler(object sender, GLMouseEventArgs e);
}
