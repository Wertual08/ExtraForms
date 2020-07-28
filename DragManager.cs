using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraForms
{
    public class DragManager
    {
        public float Step { get; set; } = 1f;
        public bool Dragging { get; private set; }
        public PointF StartLocation { get; private set; } = new PointF(float.NaN, float.NaN);
        public PointF PreviousLocation { get; private set; } = new PointF(float.NaN, float.NaN);
        public PointF CurrentLocation { get; private set; } = new PointF(float.NaN, float.NaN);
        public PointF CurrentStepLocation { get; private set; } = new PointF(float.NaN, float.NaN);
        public PointF CurrentDelta { get; private set; } = new PointF(0f, 0f);
        public PointF GlobalDelta 
        { 
            get 
            {
                if (Dragging) return new PointF(CurrentLocation.X - StartLocation.X, CurrentLocation.Y - StartLocation.Y);
                else return new PointF(0f, 0f);
            } 
        }
        public PointF CurrentStepDelta { get; private set; }
        public PointF GlobalStepDelta
        {
            get
            {
                if (Dragging) return new PointF(CurrentStepLocation.X - StartLocation.X, CurrentStepLocation.Y - StartLocation.Y);
                else return new PointF(0f, 0f);
            }
        }

        public DragManager(float step = 1f)
        {
            Step = step;
        }
        public void BeginDrag(PointF point)
        {
            StartLocation = PreviousLocation = CurrentStepLocation = CurrentLocation = point;
            CurrentDelta = new PointF(0f, 0f);
            CurrentStepDelta = new PointF(0f, 0f);
            Dragging = true;
        }
        public void UpdateLocation(PointF point)
        {
            var spoint = new PointF(CurrentLocation.X - StartLocation.X, CurrentLocation.Y - StartLocation.Y);
            if (spoint.X < 0) spoint.X -= Step / 2.0f;
            if (spoint.X > 0) spoint.X += Step / 2.0f;
            if (spoint.Y < 0) spoint.Y -= Step / 2.0f;
            if (spoint.Y > 0) spoint.Y += Step / 2.0f;
            spoint.X -= spoint.X % Step;
            spoint.Y -= spoint.Y % Step;
            spoint.X += StartLocation.X;
            spoint.Y += StartLocation.Y;
            if (Dragging)
            {
                CurrentDelta = new PointF(point.X - CurrentLocation.X, point.Y - CurrentLocation.Y);
                CurrentStepDelta = new PointF(spoint.X - CurrentStepLocation.X, spoint.Y - CurrentStepLocation.Y);
                CurrentStepLocation = spoint;
            }
            CurrentLocation = point;
            PreviousLocation = CurrentLocation;
        }
        public void EndDrag()
        {
            StartLocation = PreviousLocation = CurrentStepLocation = new PointF(float.NaN, float.NaN);
            CurrentDelta = new PointF(0f, 0f);
            CurrentStepDelta = new PointF(0f, 0f);
            Dragging = false;
        }
    }
}
