using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachView.Ucs.Monitors.Marker
{
    public class GMapDrone : GMapMarker
    {
        private Bitmap Bitmap { get; set; }

        public GMapDrone(PointLatLng pos, string id, Bitmap bitmap) : base(pos)
        {
            this.Bitmap = bitmap;


            this.Tag = id;
            this.Size = new Size(this.Bitmap.Width, this.Bitmap.Height);
            // offset.

            this.Offset = new Point(-Size.Width / 2, -Size.Height);

        }

        public void SetPosition(PointLatLng position)
        {
            this.Position = position;
        }

        public override void OnRender(Graphics g)
        {
            g.DrawImage(this.Bitmap, this.LocalPosition.X, this.LocalPosition.Y, this.Size.Width, this.Size.Height);
        }
    }
}
