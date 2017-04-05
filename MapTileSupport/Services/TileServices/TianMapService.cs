using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using MapTileSupport.Services.Interfaces;
using MapTileSupport.Services.Utilily;
using System.Xml.Linq;
using MapTileSupport.Models;

namespace MapTileSupport.Services.TileServices
{
    class TianMapService : ITileAttributeService
    {
        public PointLatLng TopRight { get; set; }

        public PointLatLng BottomLeft { get; set; }

        public int Level { get; set; }

        public List<TileAttribute> TileAttributeCollection { get; set; }

        public TianMapService(PointLatLng topRight, PointLatLng bottomLeft, int level)
        {
            this.TopRight = topRight;
            this.BottomLeft = bottomLeft;
            this.Level = level;
        }

        public List<TileAttribute> GetTileAttribute()
        {
            double MapResolution = CommonUtil.QueryMapResolution(this.Level);

            int maxRow = Convert.ToInt32(Math.Ceiling((180.0 + this.TopRight.Lng) / MapResolution * 256.0) -1);
            int maxColumn = Convert.ToInt32(Math.Ceiling((90 - this.TopRight.Lat) / MapResolution * 256)-1);

            int minRow = Convert.ToInt32(Math.Ceiling((180.0 + this.BottomLeft.Lng) / MapResolution * 256.0) - 1);
            int minColumn = Convert.ToInt32(Math.Ceiling((90 - this.BottomLeft.Lat) / MapResolution * 256) - 1);

            for (int i = minRow; i <= maxRow; i++)
            {
                for (int j = minColumn; j <= maxColumn; j++)
                {
                    TileAttribute tileAttribute = new TileAttribute(i, j, this.Level, "TianMap");
                    this.TileAttributeCollection.Add(tileAttribute);
                }
            }
            return this.TileAttributeCollection;
        }
    }
}
