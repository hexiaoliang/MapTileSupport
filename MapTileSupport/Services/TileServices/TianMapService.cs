using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using MapTileSupport.Services.Interfaces;
using System.Xml.Linq;
using MapTileSupport.Models;

namespace MapTileSupport.Services.TileServices
{
    class TianMapService : ITileAttributeService
    {
        public List<TileAttribute> TileAttributeCollection { get; private set; }

        public List<TileAttribute> GetTileAttribute(PointLatLng topRight, PointLatLng bottomLeft, int level)
        {
            double MapResolution = double.NaN;

            XElement xElement = XElement.Load(@"Data\\MapResolution.xml");

            foreach (var item in xElement.Elements("Level"))
            {
                if (item.Attribute("name").Value == level.ToString())
                {
                    MapResolution = double.Parse(item.Element("Resolution").Value);
                    break;
                }
            }

            int maxRow = Convert.ToInt32(Math.Ceiling((180.0 + topRight.Lng) / MapResolution * 256.0) -1);
            int maxColumn = Convert.ToInt32(Math.Ceiling((90 - topRight.Lat) / MapResolution * 256)-1);

            int minRow = Convert.ToInt32(Math.Ceiling((180.0 + bottomLeft.Lng) / MapResolution * 256.0) - 1);
            int minColumn = Convert.ToInt32(Math.Ceiling((90 - bottomLeft.Lat) / MapResolution * 256) - 1);

            for (int i = minRow; i <= maxRow; i++)
            {
                for (int j = minColumn; j <= maxColumn; j++)
                {
                    TileAttribute tileAttribute = new TileAttribute(i, j, level , "TianMap");
                    TileAttributeCollection.Add(tileAttribute);
                }
            }

            return TileAttributeCollection;
        }
    }
}
