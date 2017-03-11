using GMap.NET;
using MapTileSupport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTileSupport.Services.Interfaces
{
    interface ITileAttributeService
    {
        List<TileAttribute> GetTileAttribute(PointLatLng topRight, PointLatLng bottomLeft, int level);
    }
}
