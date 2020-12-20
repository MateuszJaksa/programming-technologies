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

        private void NotifyUserMethod(NotificationMessage message)
        {
            System.Windows.MessageBox.Show(message.Notification);
        }

    }
}
