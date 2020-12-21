﻿using System;
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
using Services;

namespace Presentation.ViewModel
{
    public class CatalogViewModel : ViewModelBase
    {
        private CatalogModel selectedCatalog;
        private ObservableCollection<CatalogModel> models;

        public CatalogViewModel() : base()
        {
            AddCatalogCommand = new RelayCommand(AddCatalogMethod);
            RemoveCatalogCommand = new RelayCommand(RemoveCatalogMethod);
            RefreshCatalogCommand = new RelayCommand(RefreshCatalogMethod);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("RefreshCatalog"));
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

        public void RemoveCatalogMethod()
        {
            if (SelectedCatalog != null)
            {
                LibraryRepository repository = new LibraryRepository();
                Task.Run(() => repository.RemoveCatalog(SelectedCatalog.Id));
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage("RefreshCatalog"));
            }
        }

        public void AddCatalogMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("AddCatalog"));
        }

        public void RefreshCatalogMethod()
        {
            models = CatalogModel.GetCatalogs();
            this.RaisePropertyChanged(() => this.CatalogsList);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "RefreshCatalog")
            {
                RefreshCatalogMethod();
            }
        }
    }
}