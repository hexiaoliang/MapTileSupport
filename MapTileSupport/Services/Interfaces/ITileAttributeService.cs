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
        PointLatLng TopRight { get; set; }

        PointLatLng BottomLeft { get; set; }

        int Level { get; set; }

        List<TileAttribute> TileAttributeCollection { get; set; }

        List<TileAttribute> GetTileAttribute();
    }
}
