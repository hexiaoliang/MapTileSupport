using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using MapTileSupport.Services.Interfaces;
using MapTileSupport.Models;

namespace MapTileSupport.Services.TileServices
{
    class GaodeMapService : ITileAttributeService
    {
        public List<TileAttribute> TileAttributeCollection { get; private set; }

        public List<TileAttribute> GetTileAttribute(PointLatLng topRight, PointLatLng bottomLeft, int level)
        {
            throw new NotImplementedException();
        }
    }
}
