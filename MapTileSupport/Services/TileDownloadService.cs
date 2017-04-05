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
    public class TileDownloadService : ITileDownloadService
    {
        #region 事件

        public event EventHandler<DownloadedTileEventArgs> DownloadFileCompleted;

        public event EventHandler<DownloadedTileEventArgs> DownloadProgressChanged;

        #endregion

        #region 字段

        private int _downloadedTileCount;

        #endregion

        #region 属性

        public string SavaPath { get; set; }

        public string TileUrl { get; set; }

        public List<TileAttribute> TileAttributeCollection { get; set; }

        #endregion

        #region 公开方法

        public TileDownloadService(string tileUrl, List<TileAttribute> tileAttributeCollection, string savaPath)
        {
            this.TileUrl = tileUrl;
            this.SavaPath = savaPath;
            this.TileAttributeCollection = new List<TileAttribute>(tileAttributeCollection);
        }

        public bool TileDownload()
        {
            try
            {
                foreach (var tileAttribute in this.TileAttributeCollection)
                {
                    WebClient webClient = new WebClient();

                    string clientURL = string.Format(this.TileUrl, tileAttribute.Column, tileAttribute.Row, tileAttribute.Level);

                    string savePath = string.Format(@"{0}\{1}\{2}", this.SavaPath, "L" + string.Format("{0:d2}", tileAttribute.Level), "R" + string.Format("{0:d8}", Convert.ToString((long)tileAttribute.Row, 0x10).ToUpper()));

                    if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);

                    string fileName = string.Format(@"{0}\{1}.png", savePath, "C" + string.Format("{0:d8}", Convert.ToString((long)tileAttribute.Column, 0x10).ToUpper()));

                    webClient.DownloadFileAsync(new Uri(clientURL), fileName);

                    webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;

                    webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.DownloadFileCompleted?.Invoke(this, new DownloadedTileEventArgs(this._downloadedTileCount));
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.DownloadProgressChanged?.Invoke(this, new DownloadedTileEventArgs(this._downloadedTileCount));
        }

        #endregion

        #region 内部方法



        #endregion
    }
}
