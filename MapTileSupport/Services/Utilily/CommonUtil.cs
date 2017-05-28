using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MapTileSupport.Services.Utilily
{
    public static class CommonUtil
    {
        public static double QueryMapResolution(int level, string xmlPath)
        {
            double mapResolution = double.NaN;

            XElement xElement = XElement.Load(xmlPath);

            foreach (var item in xElement.Elements("Level"))
            {
                if (item.Attribute("name").Value == level.ToString())
                {
                    mapResolution = double.Parse(item.Element("Resolution").Value);
                    break;
                }
            }
            return mapResolution;
        }
    }
}
