using MapTileSupport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using MapTileSupport.Models;
using System.Windows.Input;

namespace MapTileSupport.Services
{
    class MapLoadService : IMapLoadService
    {
        public string MapProvider { get; private set; }

        public GMapControl MainMap { get; private set; }

        public MapLoadService(string mapProvider, GMapControl mainMap) {
            this.MapProvider = mapProvider;
            this.MainMap = mainMap;
        }

        public GMapControl MapLoad()
        {
            if (this.MapProvider== "BaiduMapService")
            {
                MainMap.MapProvider = GMapProviders.GoogleChinaMap;
            }
            else if (this.MapProvider == "GaodeMapService")
            {
                MainMap.MapProvider = GMapProviders.GoogleChinaMap;
            }
            else if (this.MapProvider == "GoogleMapService")
            {
                MainMap.MapProvider = GMapProviders.GoogleChinaMap;
            }
            else if (this.MapProvider == "OSMapService")
            {
                MainMap.MapProvider = GMapProviders.OpenStreetMap;
            }
            else if (this.MapProvider == "SougouMapService")
            {
                MainMap.MapProvider = GMapProviders.GoogleChinaMap;
            }
            else if (this.MapProvider == "TencentMapService")
            {
                MainMap.MapProvider = GMapProviders.GoogleChinaMap;
            }
            else if (this.MapProvider == "TianMapService")
            {
                MainMap.MapProvider = GMapProviders.GoogleChinaMap;
            }

            return this.MainMap;
        }
    }
}
