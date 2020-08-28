using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeachView.Components
{
    public class Arrow : Control
    {
        public Arrow() : base()
        {

        }

        private int _heading = 0;
        public int Heading
        {
            get
            {
                return _heading;
            }
            set
            {
                _heading = value;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            this.DrawArrow(e.Graphics);
        }


        private double DegreesToRadians(float degrees)
        {
            return degrees * Math.PI / 180;
        }

        private void DrawArrow(Graphics g)
        {
            float cx = this.ClientSize.Width / 2f;
            float cy = this.ClientSize.Height / 2f;

            // Draw the pointer.
            // Rotate 90 degrees so North is at 0.
            // degree - 90.

            float point_legnth = this.ClientSize.Width / 3f;
            int degree = this.Heading - 90;

            float tip_x = cx + point_legnth * (float)Math.Cos(this.DegreesToRadians(degree));
            float tip_y = cy + point_legnth * (float)Math.Sin(this.DegreesToRadians(degree));
            float tip_x1 = cx + point_legnth * (float)Math.Cos(this.DegreesToRadians(degree + 120));
            float tip_y1 = cy + point_legnth * (float)Math.Sin(this.DegreesToRadians(degree + 120));
            float tip_x2 = cx + point_legnth * (float)Math.Cos(this.DegreesToRadians(degree + 240));
            float tip_y2 = cy + point_legnth * (float)Math.Sin(this.DegreesToRadians(degree + 240));


            PointF[] points = new PointF[]
            {
                new PointF(tip_x, tip_y),
                new PointF(tip_x1, tip_y1),
                new PointF(cx, cy),
                new PointF(tip_x2, tip_y2),
            };

            g.FillPolygon(Brushes.Red, points);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawString($"{Heading}", this.Font, Brushes.Blue, new PointF(cx - 5, cy - 5));
        }

    }
}
