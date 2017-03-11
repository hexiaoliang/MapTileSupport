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
        public List<TileAttribute> TileAttributeCollection { get; private set; }

        public List<TileAttribute> GetTileAttribute(PointLatLng topRight, PointLatLng bottomLeft, int level)
        {
            throw new NotImplementedException();
        }
    }
}
