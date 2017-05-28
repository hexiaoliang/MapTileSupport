using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using MapTileSupport.Models;
using MapTileSupport.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTileSupport.ViewModels
{
    class MapProviderViewModel : NotificationObject
    {
        public DelegateCommand SelectMapProviderCommand { get; set; }

        private MapLoadService _mapLoadService;

        private GMapControl _mainMap;

        public GMapControl MainMap
        {
            get { return _mainMap; }
            set
            {
                _mainMap = value;
                this.RaisePropertyChanged("MainMap");
            }
        }

        public MapProviderViewModel()
        {
            this.SelectMapProviderCommand = new DelegateCommand(new Action(SelectMapProviderExcute));

            this._mapLoadService = new MapLoadService(EnumMapProvider.GoogleChinaMap);
        }

        private void SelectMapProviderExcute()
        {
            this.MainMap = this._mapLoadService.MapLoad();
        }
    }
}
