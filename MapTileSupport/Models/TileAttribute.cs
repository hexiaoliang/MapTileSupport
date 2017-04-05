using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTileSupport.Models
{
    public class TileAttribute
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public int Level { get; set; }

        public string Provider { get; set; }

        public TileAttribute(int row, int column, int level, string provider) {
            this.Row = row;
            this.Column = column;
            this.Level = level;
            this.Provider = provider;
        }
    }
}
