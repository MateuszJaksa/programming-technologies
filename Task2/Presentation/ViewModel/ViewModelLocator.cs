using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;


namespace Presentation.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<CatalogViewModel>();
            SimpleIoc.Default.Register<StateViewModel>();
            SimpleIoc.Default.Register<AddCatalogViewModel>();
            SimpleIoc.Default.Register<EditCatalogViewModel>();
            SimpleIoc.Default.Register<AddStateViewModel>();
            SimpleIoc.Default.Register<EditStateViewModel>();
            Messenger.Default.Register<NotificationMessage>(this, NotifyUserMethod);
        }

        public CatalogViewModel CatalogViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<CatalogViewModel>();
            }
        }

        public StateViewModel StateViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<StateViewModel>();
            }
        }

        public AddCatalogViewModel AddCatalogViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<AddCatalogViewModel>();
            }
        }

        public EditCatalogViewModel EditCatalogViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<EditCatalogViewModel>();
            }
        }

        public AddStateViewModel AddStateViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<AddStateViewModel>();
            }
        }

        public EditStateViewModel EditStateViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<EditStateViewModel>();
            }
        }

        private void NotifyUserMethod(NotificationMessage message)
        {
            System.Windows.MessageBox.Show(message.Notification);
        }

    }
}
