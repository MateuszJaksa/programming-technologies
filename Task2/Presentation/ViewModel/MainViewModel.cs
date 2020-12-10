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
using Services;

namespace Presentation.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Service service;
        private ObservableCollection<StateModel> states;
        private CatalogModel selectedCatalog;
        private CatalogModel savedCatalog;

        public MainViewModel()
        {
            service = new Service();
            AddCatalogCommand = new RelayCommand(AddCatalogMethod);
            RemoveCatalogCommand = new RelayCommand(RemoveCatalogMethod);
            AddStateCommand = new RelayCommand(AddStateMethod);
            RemoveStateCommand = new RelayCommand(RemoveStateMethod);
            GuiUpdateCommand = new RelayCommand(UpdateGUIMethod);
            SaveCatalogCommand = new RelayCommand(SaveCatalogMethod);
        }

        public ICommand AddCatalogCommand { get; }
        public ICommand RemoveCatalogCommand { get; }
        public ICommand AddStateCommand { get; }
        public ICommand RemoveStateCommand { get; }
        public ICommand GuiUpdateCommand { get; }

        public ICommand SaveCatalogCommand { get; }

        public ObservableCollection<StateModel> StatesList
        {
            get
            {
                return states;
            }
        }

        public CatalogModel SelectedCatalog
        {
            get
            {
                return selectedCatalog;
            }
            set
            {
                selectedCatalog = value;
            }
        }

        public CatalogModel SavedCatalog
        {
            get
            {
                return savedCatalog;
            }
            set
            {
                savedCatalog = value;
            }
        }

        public void RemoveCatalogMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Book returned."));
        }

        public void AddCatalogMethod()
        {
            //Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Book borrowed."));
        }

        public void AddStateMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Book added."));
        }

        public void RemoveStateMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Book deleted."));
        }

        public void UpdateGUIMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("GUI updated."));
        }

        public void SaveCatalogMethod()
        {
            //Console.WriteLine(SavedCatalog.Title + " XD " + SavedCatalog.Author);
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Catalog saved."));
        }
    }
}