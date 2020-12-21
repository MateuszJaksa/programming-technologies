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
    public class StateViewModel : ViewModelBase
    {
        private StateModel selectedState;
        private ObservableCollection<StateModel> models;

        public StateViewModel()
        {
            AddStateCommand = new RelayCommand(AddStateMethod);
            RemoveStateCommand = new RelayCommand(RemoveStateMethod);
            RefreshStateCommand = new RelayCommand(RefreshStateMethod);
            EditStateCommand = new RelayCommand(EditStateMethod);
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
        public ICommand EditStateCommand { get; private set; }

        public void RemoveStateMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("State removed."));
        }

        public void AddStateMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("State added."));
        }

        public void RefreshStateMethod()
        {
            models = StateModel.GetStates();
            this.RaisePropertyChanged(() => this.StatesList);
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("States refreshed."));
        }

        public void EditStateMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("State edited."));
        }
    }
}
