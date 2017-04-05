using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using MapTileSupport.Models;
using MapTileSupport.Services.Interfaces;

namespace MapTileSupport.Services.TileServices
{
    class BaiduMapService : ITileAttributeService
    {
        public PointLatLng TopRight { get; set; }

        public PointLatLng BottomLeft { get; set; }

        public int Level { get; set; }

        public List<TileAttribute> TileAttributeCollection { get; set; }

        public List<TileAttribute> GetTileAttribute()
        {
            throw new NotImplementedException();
        }
    }
}
