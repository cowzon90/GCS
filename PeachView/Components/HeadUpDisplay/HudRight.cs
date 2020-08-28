using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeachView.Components.HeadUpDisplay
{
    public class HudRight : Control
    {
        public HudRight() : base()
        {
            try
            {
                string path = Path.Combine(Application.StartupPath, "Resources", "HUD", "compass.png");
                this._origin = new Bitmap(path);
            }
            catch (Exception)
            {
                this._origin = null;
            }
            this.DoubleBuffered = true;
        }

        #region Arrow
        public Arrow Arrow { get; set; }

        private void Init_arrow()
        {
            if (this.Arrow is null)
            {
                this.Arrow = new Arrow();
            }

            this.Arrow.ClientSize = new Size(this.Size.Width / 2, this.Size.Height / 2);
            //this.Arrow.Location = new Point(this.Location.X / 2, this.Location.Y / 2);

            int x = (this.ClientSize.Width - this.Arrow.Width) / 2;
            int y = (this.ClientSize.Height - this.Arrow.Height) / 2;

            this.Arrow.SetBounds(x, y, this.Arrow.Size.Width, this.Arrow.Size.Height);
            this.Arrow.BackColor = Color.FromArgb(1, 255, 255, 255);
            this.Arrow.Show();
            if (!this.Contains(this.Arrow))
            {
                this.Controls.Add(this.Arrow);
            }
        }
        #endregion

        private Bitmap _origin;

        /// <summary>
        /// Degree to heading
        /// </summary>
        public int Degree
        {
            get
            {
                return _degree;
            }
            set
            {
                _degree = value;
                if (this.Arrow != null)
                    this.Arrow.Heading = _degree;
            }
        }
        private int _degree = 0;

        #region Resizing
        private GraphicsPath _gp;
        private void DoResize()
        {
            this._gp = new GraphicsPath();
            this._gp.FillMode = FillMode.Winding;

            var radius = Math.Min(this.ClientSize.Width, this.ClientSize.Height);
            this._gp.AddEllipse(0, 0, radius, radius);
            this.Region = new Region(this._gp);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //this.Init_arrow();
            this.DoResize();
        }
        #endregion

        private void DrawArrow(Graphics g)
        {
            float cx = this.ClientSize.Width / 2f;
            float cy = this.ClientSize.Height / 2f;

            // Draw the pointer.
            // Rotate 90 degrees so North is at 0.
            // degree - 90.

            float point_legnth = this.ClientSize.Width / 10f;
            int degree = this.Degree - 90;

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
            g.DrawString($"{Degree}", this.Font, Brushes.Blue, new PointF(cx - 5, cy - 5));
        }

        private void DoPaint(Graphics g)
        {
            if(this._gp != null)
            {
                g.FillPath(new SolidBrush(Color.Transparent), _gp);
                g.SmoothingMode = SmoothingMode.HighQuality;
            }

            if(_origin != null)
            {
                Bitmap resize = new Bitmap(_origin, this.ClientSize);
                g.DrawImage(resize, this.ClientRectangle.Location);
            }

            this.DrawArrow(g);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //if (this.BackgroundImage is null)
            //{
            //    this.DrawBackground(e.Graphics);
            //    return;
            //}
            this.DoPaint(e.Graphics);
        }

        private double DegreesToRadians(float degrees)
        {
            return degrees * Math.PI / 180;
        }

        #region Draw Background
        private void DrawBackground(Graphics gr)
        {
            float cx = this.ClientSize.Width / 2f;
            float cy = this.ClientSize.Height / 2f;

            // Draw NSEW.
            float letter_r = Math.Min(cx, cy) * 0.85f;
            string[] letters = { "N", "E", "S", "W" };
            int[] degrees = { 270, 0, 90, 180 };
            for (int i = 0; i < 4; i++)
            {
                float letter_x = letter_r * (float)Math.Cos(DegreesToRadians(degrees[i]));
                float letter_y = letter_r * (float)Math.Sin(DegreesToRadians(degrees[i]));
                PointF point = new PointF(cx + letter_x, cy + letter_y);
                DrawRotatedText(gr, this.Font, Brushes.Black,
                    letters[i], point, degrees[i] + 90);
            }

            // Draw tick marks.
            const int large_tick_freq = 30; // Draw a large tick mark every 30 degrees.
            const int small_tick_freq = 15; // Draw a small tick mark every 15 degrees.
            const int tiny_tick_freq = 3;   // Draw a tiny tick mark every 3 degrees.
            float outer_r = letter_r * 0.9f;
            float large_r = outer_r * 0.8f;
            float small_r = outer_r * 0.9f;
            float tiny_r = outer_r * 0.95f;
            using (Pen pen = new Pen(Color.Blue, 3))
            {
                for (int i = tiny_tick_freq; i <= 360; i += tiny_tick_freq)
                {
                    float cos = (float)Math.Cos(DegreesToRadians(i));
                    float sin = (float)Math.Sin(DegreesToRadians(i));
                    float x0 = cx + outer_r * cos;
                    float y0 = cy + outer_r * sin;

                    float x1, y1;
                    if (i % large_tick_freq == 0)
                    {
                        pen.Width = 3;
                        x1 = cx + large_r * cos;
                        y1 = cy + large_r * sin;
                    }
                    else if (i % small_tick_freq == 0)
                    {
                        pen.Width = 2;
                        x1 = cx + small_r * cos;
                        y1 = cy + small_r * sin;
                    }
                    else
                    {
                        pen.Width = 1;
                        x1 = cx + tiny_r * cos;
                        y1 = cy + tiny_r * sin;
                    }
                    gr.DrawLine(pen, x0, y0, x1, y1);
                }
            }
        }

        private void DrawRotatedText(Graphics gr, Font font, Brush brush, string text, PointF location, float degrees)
        {
            GraphicsState state = gr.Save();
            gr.ResetTransform();
            gr.RotateTransform(degrees);
            gr.TranslateTransform(location.X, location.Y, MatrixOrder.Append);
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                gr.DrawString(text, font, brush, 0, 0, sf);
            }
            gr.Restore(state);
        }
        #endregion
    }
}
