using MapTileSupport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTileSupport.Services.Interfaces
{
    interface ITileDownloadService
    {
        string SavaPath { get; set; }

        string TileUrl { get; set; }

        List<TileAttribute> TileAttributeCollection { get; set; }

        bool TileDownload();

        event EventHandler<DownloadedTileEventArgs> DownloadFileCompleted;

        event EventHandler<DownloadedTileEventArgs> DownloadProgressChanged;
    }

    public class DownloadedTileEventArgs : EventArgs
    {
        public DownloadedTileEventArgs(int tileCount)
            : base()
        {
            DownloadedTileCount = tileCount;
        }

        public int DownloadedTileCount { get; set; }
    }
}
