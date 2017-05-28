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
        public EnumMapProvider MapProvider { get; set; }

        private GMapControl _mainMap = new GMapControl();

        public MapLoadService(EnumMapProvider mapProvider)
        {
            this.MapProvider = mapProvider;
        }

        public GMapControl MapLoad()
        {
            switch (this.MapProvider)
            {
                case EnumMapProvider.OpenStreetMap:
                    this._mainMap.MapProvider = GMapProviders.OpenStreetMap;
                    break;
                case EnumMapProvider.GoogleChinaMap:
                    this._mainMap.MapProvider = GMapProviders.GoogleChinaMap;
                    break;
                case EnumMapProvider.BaiduMap:
                    this._mainMap.MapProvider = GMapProviders.OpenStreetMap;
                    break;
                case EnumMapProvider.GaodeMap:
                    this._mainMap.MapProvider = GMapProviders.OpenStreetMap;
                    break;
                case EnumMapProvider.TencentMap:
                    this._mainMap.MapProvider = GMapProviders.OpenStreetMap;
                    break;
                case EnumMapProvider.SougouMap:
                    this._mainMap.MapProvider = GMapProviders.OpenStreetMap;
                    break;
                case EnumMapProvider.TianMap:
                    this._mainMap.MapProvider = GMapProviders.OpenStreetMap;
                    break;
                case EnumMapProvider.TianLabelMap:
                    this._mainMap.MapProvider = GMapProviders.OpenStreetMap;
                    break;
                default:
                    break;
            }
            return this._mainMap;
        }
    }
}
