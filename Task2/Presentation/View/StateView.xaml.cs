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

namespace Presentation.View
{
    public partial class StateView : UserControl
    {
        public StateView()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            AddStateView view = new AddStateView();

            if (msg.Notification == "AddState")
            {
                
                view.Show();
            }

            if (msg.Notification == "CloseAddState")
            {
                view.Hide();
            }
        }
    }
}
