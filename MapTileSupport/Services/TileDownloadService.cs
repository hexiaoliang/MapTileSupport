using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapTileSupport.Services.Interfaces;
using System.Net;
using System.Threading;
using System.ComponentModel;
using MapTileSupport.Models;
using System.IO;

namespace MapTileSupport.Services
{
    class TileDownloadService : ITileDownloadService
    {
        public int DownloadedTileCount { get; private set; }

        public string SavaPath { get; private set; }

        public string TileUrl { get; private set; }

        public List<TileAttribute> TileAttributeCollection { get; private set; }

        public TileDownloadService(string tileUrl, List<TileAttribute> tileAttributeCollection, string savaPath) {

            this.TileUrl = tileUrl;
            this.TileAttributeCollection = new List<TileAttribute>(tileAttributeCollection);
            this.SavaPath = savaPath;
        }

        /// <summary>
        ///  Thread thread = new Thread(new ThreadStart(() => TileDownload()));
        ///  thread.Start();
        /// </summary>
        public void TileDownload()
        {
            foreach (var tileAttribute in this.TileAttributeCollection)
            {
                WebClient webClient = new WebClient();

                string clientURL = string.Format(this.TileUrl, tileAttribute.Column, tileAttribute.Row, tileAttribute.Level);

                string savePath = string.Format(@"{0}\{1}\{2}", this.SavaPath, 
                                                "L" + string.Format("{0:d2}", tileAttribute.Level),
                                                "R" + string.Format("{0:d8}", Convert.ToString((long)tileAttribute.Row, 0x10).ToUpper()));

                if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);

                string fileName = string.Format(@"{0}\{1}.png", savePath, "C" + string.Format("{0:d8}", Convert.ToString((long)tileAttribute.Column, 0x10).ToUpper()));

                webClient.DownloadFileAsync(new Uri(clientURL), fileName);

                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);

                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
            }
        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
