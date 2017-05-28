using MapTileSupport.Models;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Windows.Input;
using System.Windows;

namespace MapTileSupport.ViewModels
{
    class MainMapViewModel : NotificationObject
    {
        private CurrentInfo _currentInfo;

        public CurrentInfo CurrentInfo
        {
            get { return _currentInfo; }
            set
            {
                _currentInfo = value;
                this.RaisePropertyChanged("CurrentInfo");
            }
        }

        private GMapControl _mainMap;

        private PointLatLng _lastPosition;

        private bool _isLeftButtonDown;

        public GMapControl MainMap
        {
            get { return _mainMap; }
            set
            {
                _mainMap = value;
                this.RaisePropertyChanged("MainMap");
            }
        }

        public MainMapViewModel()
        {
            this.InitMapControl();

            this.LoadCurrentInfo();
        }

        private void LoadCurrentInfo()
        {
            this.CurrentInfo = new CurrentInfo();

            //this.CurrentInfo.Latitude
        }

        private void InitMapControl()
        {
            MainMap.MapProvider = GMapProviders.OpenStreetMap;

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
            MainMap.MouseDoubleClick += MainMap_MouseDoubleClick;
            MainMap.MouseUp += MainMap_MouseUp;
            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;
        }

        private void MainMap_OnMapZoomChanged()
        {
            this.CurrentInfo.Zoom = string.Format("地图级别：{0}", MainMap.Zoom.ToString("00"));
            this.CurrentInfo.MapProvider = string.Format("地图提供：{0}", MainMap.MapProvider);
        }
        
        private void MainMap_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this._isLeftButtonDown = false;
        }

        private void MainMap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MainMap.Zoom += 1;
                MainMap.Position = this._lastPosition;
            }
        }

        private void MainMap_Loaded(object sender, RoutedEventArgs e)
        {
            this.CurrentInfo.Latitude = string.Format("纬度：{0}", MainMap.Position.Lat.ToString("0.00000000"));
            this.CurrentInfo.Longitude = string.Format("经度：{0}", MainMap.Position.Lng.ToString("0.00000000"));
            this.CurrentInfo.Zoom = string.Format("地图级别：{0}", MainMap.Zoom.ToString("00"));
            this.CurrentInfo.MapProvider = string.Format("地图提供：{0}", MainMap.MapProvider);
        }
    }
}
