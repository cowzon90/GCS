using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeachView.Components
{
    public class DualTrackBar : Control
    {
        private int rangeMinValue;
        private int rangeMaxValue;

        private int _value;
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                if(value == _value)
                {
                    return;
                }

                _value = value;

                if(MinValue >= _value)
                {
                    MinValue = _value;
                }
                if (MaxValue <= _value)
                {
                    MaxValue = _value;
                }
             
                this.Invalidate();
            }
        }

        public int LineThick { get; set; } = 5;
        public int BarPadding { get; set; } = 5;

        public Color LineColor { get; set; } = Color.BlanchedAlmond;
        private int CircleRadius = 10;

        public void SetRange(int minValue, int maxValue)
        {
            this.rangeMinValue = minValue;
            this.rangeMaxValue = maxValue;

            this.Value = (minValue + maxValue) / 2;
            this.MinValue = Value;
            this.MinValue = Value;
            this.Invalidate();
        }

        public DualTrackBar()
        {
            this.SetRange(0, 100);    // by default;

            this.Click += DualTrackBar_Click;

        }

        private void DualTrackBar_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"position : {this.Location.X}, {this.Location.Y}");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);



            this.DrawBar_line(e.Graphics);
            this.DrawCircles(e.Graphics);
        }

        private void DrawBar_line(Graphics g)
        {
            // center
            int center = (this.ClientRectangle.Y + this.ClientRectangle.Height) / 2;
            center -= (this.LineThick / 2);

            Pen line_pen = new Pen(LineColor, this.LineThick);

            // TOOD : left, right padding.
            Point left = new Point(this.ClientRectangle.X + this.CircleRadius, center);
            Point right = new Point(this.ClientRectangle.X + this.ClientRectangle.Width - this.CircleRadius, center);
            g.DrawLine(line_pen, left, right);

        }

        private int GetLineLength()
        {
            return (this.ClientRectangle.Width - this.CircleRadius * 2);
        }

        private Point GetLeftTopOfCircle(int value)
        {

            int diff = (this.rangeMaxValue - this.rangeMinValue);
            int bar_legnth = this.GetLineLength();
            try
            {
                int topx = ((value * bar_legnth) / diff);
                Point point = new Point(topx, this.ClientRectangle.Y + this.CircleRadius);
                return point;
            }
            catch (Exception e)
            {
                return new Point();
            }
        }

        private void DrawCircles(Graphics g)
        {
            Size size = new Size(this.CircleRadius * 2, this.CircleRadius * 2);

            List<int> circle_values = new List<int>() { this.MinValue, this.MaxValue, this.Value };
            List<Pen> pens = new List<Pen>()
            {
                new Pen(Brushes.Blue, 1), new Pen(Brushes.Red, 1), new Pen(Brushes.Black, 1)
            };

            foreach(var item in circle_values.Zip(pens, Tuple.Create))
            {
                Rectangle rect = new Rectangle(this.GetLeftTopOfCircle(item.Item1), size);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.DrawEllipse(item.Item2, rect);
                g.FillEllipse(new SolidBrush(item.Item2.Color), rect);
            }

        }


    }
}
