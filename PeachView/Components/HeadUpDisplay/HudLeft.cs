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
    public class HudLeft : Control
    {
        public HudLeft() : base()
        {
            try
            {
                string imagepath = Path.Combine(Application.StartupPath, "Resources", "HUD", "back_gradation_bar.png");
                _origin = new Bitmap(imagepath);
            }
            catch (Exception e)
            {
                _origin = new Bitmap(10, 10);
            }

            //this.BackColor = Color.Transparent;
            this.ForeColor = Color.Transparent;
            this.DoubleBuffered = true;
        }

        private Bitmap _origin;
        private Bitmap _resized;
        private Bitmap _imageTarget;

        private double _roll = 0;
        
        /// <summary>
        /// Roll value
        /// </summary>
        public double Roll
        {
            get
            {
                return _roll;
            }
            set
            {
                _roll = value;
                this.Invalidate();
            }
        }

        private double _pitch = 0;
        /// <summary>
        /// Pitch value
        /// </summary>
        public double Pitch
        {
            get
            {
                return _pitch;
            }
            set
            {
                _pitch = value;
                this.Invalidate();
            }
        }

        #region Resizing
        private GraphicsPath _gp;
        private void DoResize()
        {
            _gp = new GraphicsPath();
            _gp.FillMode = FillMode.Winding;
            var radius = Math.Min(this.Size.Width, this.Size.Height);
            _gp.AddEllipse(0, 0, radius, radius);
            this.Region = new Region(_gp);

            // image resizing
            if (_origin != null)
            {
                // 15 degree viewing.
                int height = this.ClientSize.Height * 180 / 30;
                _resized = new Bitmap(_origin, this.ClientSize.Width, height);
                this.DrawVerticalLines(_resized);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            // TODO :
            base.OnResize(e);

            this.DoResize();
        }
        #endregion

        #region Paint
        private void DoPaint(Graphics g)
        {
            if (_gp != null)
            {
                g.FillPath(new SolidBrush(Color.Transparent), _gp);
                g.SmoothingMode = SmoothingMode.HighQuality;
            }

            if (_resized != null)
            {
                Bitmap copy = (Bitmap)_resized.Clone();

                // vertical rotation
                _imageTarget = this.SelectRoi(copy, (float)this.Pitch);

                // horizontal(clock wise) rotation.
                _imageTarget = this.RotateImage(_imageTarget, (float)this.Roll);
                this.DrawReverseTriange(_imageTarget);

                Rectangle r = this.DisplayRectangle;
                g.DrawImage(_imageTarget, this.Location);
            }

            // TODO : 
            g.DrawString($"p : {this.Pitch}, r : {this.Roll}", this.Font, Brushes.Red, new PointF(30, 30));
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        private Bitmap SelectRoi(Bitmap bitmap, float angle)
        {
            float unit = (float)(bitmap.Height / 2) / 90f;

            // calculate roi area.
            float x = 0;
            float degree_y = unit * (angle + 1);
            float y = bitmap.Height / 2 - this.Size.Width / 2 - (degree_y);
            float width = this.Size.Width;
            float height = this.Size.Height;
            RectangleF cropF = new RectangleF(x, y, width, height);

            Bitmap roi;
            try
            {
                if (cropF.Y < 0 || cropF.Y + cropF.Height > bitmap.Height)
                {
                    Bitmap top, bottom, vstack = null;

                    if (angle > 0)
                    {
                        top = (Bitmap)bitmap.Clone();
                        top.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        bottom = bitmap;
                        vstack = this.VStack(top, bottom);
                        cropF.Y = (float)(vstack.Height / 2) + cropF.Y;
                    }
                    else
                    {
                        top = bitmap;
                        bottom = (Bitmap)bitmap.Clone();
                        bottom.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        vstack = this.VStack(top, bottom);
                    }
                    roi = vstack.Clone(cropF, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                }
                else
                {
                    roi = bitmap.Clone(cropF, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                }


                return roi;
            }
            catch (Exception)
            {
                return new Bitmap((int)width, (int)height);
            }
        }

        /// <summary>
        /// Draw point as center.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="diagonal"></param>
        private void DrawReverseTriange(Bitmap bitmap, float diagonal = 5.0f)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                float cx = bitmap.Width / 2f;
                float cy = bitmap.Height / 2f;

                PointF[] points = new PointF[]
                {
                    //center
                    new PointF(cx, cy),
                    //left
                    new PointF(cx - diagonal, cy - diagonal),
                    //right
                    new PointF(cx + diagonal, cy - diagonal),
                };

                g.DrawPolygon(new Pen(Color.Red, 3), points);
                g.FillPolygon(Brushes.Red, points);
                g.SmoothingMode = SmoothingMode.HighQuality;
            }
        }

        /// <summary>
        /// Draw Vertical lines.
        /// </summary>
        /// <param name="bitmap"></param>
        private void DrawVerticalLines(Bitmap bitmap)
        {
            // draw lines.
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // TODO : 
                int total_line_number = 21;

                float h_unit = ((float)bitmap.Height / (float)total_line_number);
                float cx = bitmap.Width / 2f;
                float w_unit = cx / 5f;

                List<PointF> lefts = new List<PointF>();
                for (int i = 0; i < total_line_number + 1; i++)
                {
                    float x = cx - w_unit * 2;
                    float y = h_unit * i;
                    if (i % 3 == 0)
                    {
                        x -= w_unit;
                    }

                    lefts.Add(new PointF(x, y));
                }

                foreach (PointF point in lefts)
                {
                    g.DrawLine(new Pen(Color.Black, 2), point, new PointF(-point.X + 2 * cx, point.Y));
                }
            }
        }

        /// <summary>
        /// merge two bitmap image vertically.
        /// </summary>
        /// <param name="top"></param>
        /// <param name="bottom"></param>
        /// <returns></returns>
        private Bitmap VStack(Bitmap top, Bitmap bottom)
        {
            Bitmap sum = new Bitmap(Math.Min(top.Width, bottom.Width), Math.Min(top.Height, bottom.Height) * 2);

            using (Graphics g = Graphics.FromImage(sum))
            {
                g.DrawImage(top, Point.Empty);
                g.DrawImage(bottom, new Point(0, top.Height));
            }

            return sum;
        }

        /// <summary>
        /// rotate image into clock wise with angle.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        private Bitmap RotateImage(Bitmap bitmap, float angle)
        {
            //create an empty Bitmap image
            //Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bitmap);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bitmap.Width / 2, (float)bitmap.Height / 2);

            //now rotate the image
            gfx.RotateTransform(angle);

            gfx.TranslateTransform(-(float)bitmap.Width / 2, -(float)bitmap.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(bitmap, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bitmap;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            this.DoPaint(e.Graphics);
        }
        #endregion

    }
}
