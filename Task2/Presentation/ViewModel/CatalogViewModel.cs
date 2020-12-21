using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Presentation.Model;

namespace Presentation.ViewModel
{
    public class CatalogViewModel : ViewModelBase
    {
        private CatalogModel selectedCatalog;
        private ObservableCollection<CatalogModel> models;

        public CatalogViewModel()
        {
            AddCatalogCommand = new RelayCommand(AddCatalogMethod);
            RemoveCatalogCommand = new RelayCommand(RemoveCatalogMethod);
            RefreshCatalogCommand = new RelayCommand(RefreshCatalogMethod);
            EditCatalogCommand = new RelayCommand(EditCatalogMethod);
        }

        public CatalogModel SelectedCatalog
        {
            get { return selectedCatalog; }
            set
            {
                selectedCatalog = value;
                RaisePropertyChanged("SelectedCatalog");
            }
        }

        public ObservableCollection<CatalogModel> CatalogsList
        {
            get { return models; }
        }

        public ICommand AddCatalogCommand { get; private set; }
        public ICommand RemoveCatalogCommand { get; private set; }
        public ICommand RefreshCatalogCommand { get; private set; }
        public ICommand EditCatalogCommand { get; private set; }

        public void RemoveCatalogMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Catalog removed."));
        }

        public void AddCatalogMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Catalog added."));
        }

        public void RefreshCatalogMethod()
        {
            models = CatalogModel.GetCatalogs();
            this.RaisePropertyChanged(() => this.CatalogsList);
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Catalogs refreshed."));
        }

        public void EditCatalogMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Catalog edited."));
        }
    }
}