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
using Services;

namespace Presentation.ViewModel
{
    public class StateViewModel : ViewModelBase
    {
        private StateModel selectedState;
        private ObservableCollection<StateModel> models;

        public StateViewModel() : base()
        {
            AddStateCommand = new RelayCommand(AddStateMethod);
            RemoveStateCommand = new RelayCommand(RemoveStateMethod);
            RefreshStateCommand = new RelayCommand(RefreshStateMethod);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("RefreshState"));
        }

        public StateModel SelectedState
        {
            get { return selectedState; }
            set
            {
                selectedState = value;
                RaisePropertyChanged("SelectedState");
            }
        }

        public ObservableCollection<StateModel> StatesList
        {
            get { return models; }
        }

        public ICommand AddStateCommand { get; private set; }
        public ICommand RemoveStateCommand { get; private set; }
        public ICommand RefreshStateCommand { get; private set; }

        public void RemoveStateMethod()
        {
            if (SelectedState != null)
            {
                LibraryRepository repository = new LibraryRepository();
                Task.Run(() => repository.RemoveState(SelectedState.Id));
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage("RefreshState"));
            }
        }

        public void AddStateMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("AddState"));
        }

        public void RefreshStateMethod()
        {
            models = StateModel.GetStates();
            this.RaisePropertyChanged(() => this.StatesList);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "RefreshState")
            {
                RefreshStateMethod();
            }
        }
    }
}
