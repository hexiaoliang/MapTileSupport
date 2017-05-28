using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTileSupport.Models
{
    class CurrentInfo : NotificationObject
    {
        private string _latitude;

        public string Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                this.RaisePropertyChanged("Latitude");
            }
        }

        private string _longitude;

        public string Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                this.RaisePropertyChanged("Longitude");
            }
        }

        private string _zoom;

        public string Zoom
        {
            get { return _zoom; }
            set
            {
                _zoom = value;
                this.RaisePropertyChanged("Zoom");
            }
        }

        private string _mapProvider;

        public string MapProvider
        {
            get { return _mapProvider; }
            set
            {
                _mapProvider = value;
                this.RaisePropertyChanged("MapProvider");
            }
        }
    }
}
