using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeachView.Components
{
    public class CircleButton : Button
    {
        public CircleButton() : base()
        {

        }

        protected override void OnPaint(PaintEventArgs p)
        {

            Pen pen = new Pen(this.BackColor);

            p.Graphics.DrawEllipse(pen, this.ClientRectangle);
            p.Graphics.FillEllipse(Brushes.Blue, this.ClientRectangle);

        }

    }
}
