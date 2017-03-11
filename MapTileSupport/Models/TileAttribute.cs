using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTileSupport.Models
{
    class TileAttribute
    {
        public int Row { get; private set; }

        public int Column { get; private set; }

        public int Level { get; private set; }

        public string Provider { get; private set; }

        public TileAttribute(int row, int column, int level, string provider) {
            this.Row = row;
            this.Column = column;
            this.Level = level;
            this.Provider = provider;
        }
    }
}
