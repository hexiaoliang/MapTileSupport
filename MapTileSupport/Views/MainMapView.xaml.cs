using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;

namespace MapTileSupport.Views
{
    /// <summary>
    /// MainMapView.xaml 的交互逻辑
    /// </summary>
    public partial class MainMapView : Page
    {
        public PointLatLng lastPosition;

        public RectLatLng tileExtent;

        public bool isLeftButtonDownFlag;

        public MainMapView()
        {
            InitializeComponent();

            InitMapControl();
        }

        private void InitMapControl()
        {

            MainMap.CacheLocation = @"..//..//..//MapCache/";

            //MainMap.MapProvider = GMapProviders.OpenStreetMap;
            MainMap.MapProvider = GMapProviders.GoogleChinaMap;

            MainMap.DragButton = MouseButton.Left;
            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            MainMap.MaxZoom = 24;
            MainMap.MinZoom = 0;
            MainMap.Zoom = 12;
            //MainMap.MapProvider.Area = new RectLatLng(30.981178, 105.351914, 2.765142, 4.120995);
            //MainMap.BoundsOfMap = new RectLatLng(30.981178, 105.351914, 2.765142, 4.120995);
            MainMap.Position = new PointLatLng(39.90, 116.40);

            //MainMap.ShowTileGridLines = true;

            MainMap.Loaded += MainMap_Loaded;

            MainMap.MouseMove += MainMap_MouseMove;
            MainMap.MouseDoubleClick += MainMap_MouseDoubleClick;
            MainMap.MouseDown += MainMap_MouseDown;
            MainMap.MouseUp += MainMap_MouseUp;
            MainMap.MouseWheel += MainMap_MouseWheel;

            MainMap.OnPositionChanged += MainMap_OnPositionChanged;
            MainMap.OnTileLoadStart += MainMap_OnTileLoadStart;
            MainMap.OnTileLoadComplete += MainMap_OnTileLoadComplete;

            //MainMap.OnMarkerClick += new MarkerClick(MainMap_OnMarkerClick);
            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;
            MainMap.OnMapTypeChanged += MainMap_OnMapTypeChanged;
        }

        private void MainMap_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            //txb_CurrentZoom.Text = string.Format("地图级别：{0}   地图提供：{1}", MainMap.Zoom.ToString("00"), MainMap.MapProvider);
        }

        private void MainMap_OnMapTypeChanged(GMapProvider type)
        {
            //throw new NotImplementedException();
        }

        private void MainMap_OnMapZoomChanged()
        {
            txb_CurrentZoom.Text = string.Format("地图级别：{0}", MainMap.Zoom.ToString("00"));
            txb_CurrentMapProvider.Text = string.Format("地图提供：{0}", MainMap.MapProvider);
        }

        private void MainMap_OnTileLoadComplete(long ElapsedMilliseconds)
        {
            //throw new NotImplementedException();
        }

        private void MainMap_OnTileLoadStart()
        {
            //throw new NotImplementedException();
        }

        private void MainMap_OnPositionChanged(PointLatLng point)
        {
            //if (isLeftButtonDownFlag)
            //{
            //    MainMap.Position = point;
            //    MainMap.ReloadMap();
            //}
            //throw new NotImplementedException();
        }

        private void MainMap_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("MainMap_MouseUp");
            isLeftButtonDownFlag = false;
            //throw new NotImplementedException();
        }

        private void MainMap_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                isLeftButtonDownFlag = true;
                lastPosition = MainMap.FromLocalToLatLng(Convert.ToInt32(e.GetPosition(this).X), Convert.ToInt32(e.GetPosition(this).Y));
                //MessageBox.Show();
            }
        }

        private void MainMap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MainMap.Zoom += 1;
                MainMap.Position = lastPosition;
            }
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            PointLatLng latLng = MainMap.FromLocalToLatLng(Convert.ToInt32(e.GetPosition(this).X), Convert.ToInt32(e.GetPosition(this).Y));
            txb_CurrentLatitude.Text = string.Format("纬度：{0}", latLng.Lat.ToString("0.00000000"));
            txb_CurrentLongitude.Text = string.Format("经度：{0}", latLng.Lng.ToString("0.00000000"));
        }

        private void MainMap_Loaded(object sender, RoutedEventArgs e)
        {
            txb_CurrentLatitude.Text = string.Format("纬度：{0}", MainMap.Position.Lat.ToString("0.00000000"));
            txb_CurrentLongitude.Text = string.Format("经度：{0}", MainMap.Position.Lng.ToString("0.00000000"));
            txb_CurrentZoom.Text = string.Format("地图级别：{0}", MainMap.Zoom.ToString("00"));
            txb_CurrentMapProvider.Text = string.Format("地图提供：{0}", MainMap.MapProvider);
        }
    }
}
