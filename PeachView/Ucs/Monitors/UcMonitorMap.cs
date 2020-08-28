using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using System.IO;
using PeachView.Ucs.Monitors.Marker;
using PeachController.Controllers;
using PeachView.Ucs.Common;

namespace PeachView.Ucs.Monitors
{
    public partial class UcMonitorMap : UserControl, IUcTops
    {
        public UcMonitorMap()
        {
            InitializeComponent();
        }

        protected Timer Timer { get; set; }
        protected double Longitude { get; set; }
        protected double Latitude { get; set; }

        // TODO : 
        public void Track()
        {
            this.Timer.Start();
        }
        // TODO : 
        public void UnTrack()
        {
            this.Timer.Stop();
        }

        public void SetTops(List<Control> controls)
        {
            foreach (Control c in controls)
            {
                if (this.gMapControl.Controls.Contains(c)) continue;
                this.gMapControl.Controls.Add(c);
            }
        }

        public void SetBottomHud(Label label)
        {
            this.gMapControl.Controls.Add(label);
        }

        #region Init UI
        private void InitUI_UcMonitorMap_NoJapanSea()
        {
            PointLatLng ptSeaJapanPos = new PointLatLng();
            ptSeaJapanPos.Lat = 39.8;
            ptSeaJapanPos.Lng = 134.3;

            List<PointLatLng> points = new List<PointLatLng>();
            double lat = 0.15, lng = 0.4;
            points.Add(new PointLatLng(ptSeaJapanPos.Lat - lat, ptSeaJapanPos.Lng - lng));
            points.Add(new PointLatLng(ptSeaJapanPos.Lat - lat, ptSeaJapanPos.Lng + lng));
            points.Add(new PointLatLng(ptSeaJapanPos.Lat + lat, ptSeaJapanPos.Lng + lng));
            points.Add(new PointLatLng(ptSeaJapanPos.Lat + lat, ptSeaJapanPos.Lng - lng));

            GMapOverlay noJapanOverlay = new GMapOverlay();

            // block
            GMapPolygon polygon = new GMapPolygon(points, "No JapanSea");
            polygon.Fill = new SolidBrush(Color.FromArgb(255, 75, 98, 165));
            polygon.Stroke = new Pen(Brushes.Transparent);
            polygon.Tag = "NoJapanSea";
            noJapanOverlay.Polygons.Add(polygon);
            gMapControl.Overlays.Add(noJapanOverlay);
            //(polygon.Shape as Path).Opacity = 1;

            // Label
            Label text = new Label();
            text.Text = "East Sea";
            text.TextAlign = ContentAlignment.MiddleCenter;
            text.Width = 200;
            text.Height = 80;

            //GMapPolygon labelPolygon = new GMapPolygon(ptSeaJapanPos);
            //GMapMarker marker = new GMapMarker(ptSeaJapanPos);
            //marker.Tag = "NoJapanSea";
            //marker.Shape = text;
            //marker.Offset = new Point(-text.Width / 2, -text.Height / 2);
            //text.Foreground = Brushes.White;
            ////text.Background = Brushes.Transparent;
            //gMapControl.Overlays.Add(marker);
        }

        private void InitUI_UcMonitorMap_Default()
        {
            gMapControl.EmptyMapBackground = Color.Navy;
            gMapControl.MouseWheelZoomEnabled = true;
            gMapControl.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            gMapControl.DragButton = MouseButtons.Left;
            gMapControl.MapProvider = GMapProviders.GoogleHybridMap;  //Map Data Provider Set

            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            string strPath = AppDomain.CurrentDomain.BaseDirectory;
            gMapControl.CacheLocation = strPath;
            GMaps.Instance.Mode = AccessMode.ServerOnly;

            gMapControl.MaxZoom = 19;                   //Limit Maximum Zoom Value
            gMapControl.MinZoom = 7;                    //Limit Minimum Zoom Value
            gMapControl.Zoom = 7;                       //Default Zoom Value

            // 지도 초기 위치
            gMapControl.Position = new PointLatLng(36.432441, 127.395067);  //초기위치 국과연 운동장

            // 지도 중앙 false
            gMapControl.ShowCenter = false;
            gMapControl.IgnoreMarkerOnMouseWheel = true;
        }

        private void InitUI_Timer()
        {
            this.Timer = new Timer();
            this.Timer.Interval = 250;// 250millisec;
            this.Timer.Tick += Timer_Tick;
        }

        private void InitUI_UcMonitorMap()
        {
            this.InitUI_UcMonitorMap_NoJapanSea();

            this.InitUI_UcMonitorMap_Default();

            this.InitUI_Timer();

        }

        #endregion

        #region Events

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (InterfaceController.Instance.GetCurrentVehicle() == null)
            {
                // not connected.
                return;
            }

            this.Longitude = InterfaceController.Instance.GetCurrentVehicle().Longitude;
            this.Latitude = InterfaceController.Instance.GetCurrentVehicle().Latitude;

            this.UavPosition = new PointLatLng(Latitude, Longitude);
            //Debug.WriteLine(this.UavPosition);
            this.SetCenter(this.UavPosition);

        }

        private void UcMap_Load(object sender, EventArgs e)
        {
            this.InitUI_UcMonitorMap();

        }
        #endregion

        #region Draw Uav
        private string flightname = "flight";
        private void DrawUAV(PointLatLng point)
        {
            GMapOverlay overlay = this.gMapControl.Overlays.Where(uav => uav.Id == this.flightname).FirstOrDefault();

            if (overlay is null)
            {
                // make
                GMapOverlay t_overlay = new GMapOverlay(this.flightname);

                string bitmapPath = Path.Combine(Application.StartupPath, "Resources", "drone32.png");
                Bitmap drone_image = new Bitmap(bitmapPath);

                GMapDrone t_drone = new GMapDrone(point, this.flightname, drone_image);
                t_overlay.Markers.Add(t_drone);
                this.gMapControl.Overlays.Add(t_overlay);
                return;
            }

            var drone = overlay.Markers.Where(marker => (string)marker.Tag == this.flightname).FirstOrDefault();

            if (drone is null)
            {
                return;
            }

            (drone as GMapDrone).SetPosition(point);
        }
        private PointLatLng UavPosition { get; set; }
        private void SetCenter(PointLatLng center)
        {
            this.Invoke((Action)delegate
            {
                this.gMapControl.Position = center;
                this.DrawUAV(center);
            });
        }
        #endregion
    }
}
