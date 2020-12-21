using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using Presentation.ViewModel;

namespace Presentation.View
{
    public partial class CatalogView : UserControl
    {
        private AddCatalogView addView = new AddCatalogView();

        public CatalogView()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "AddCatalog")
            {
                addView = new AddCatalogView();
                addView.Show();
            }

            if (msg.Notification == "CloseAddCatalog")
            {
                addView.Hide();
            }
        }
    }
}
