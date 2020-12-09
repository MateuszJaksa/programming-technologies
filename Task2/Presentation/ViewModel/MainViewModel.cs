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
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<StateModel> states;
        private StateModel selectedState;

        public MainViewModel()
        {
            BorrowBookCommand = new RelayCommand(BorrowBookMethod);
            ReturnBookCommand = new RelayCommand(ReturnBookMethod);
            AddBookCommand = new RelayCommand(AddBookMethod);
            DeleteBookCommand = new RelayCommand(DeleteBookMethod);
            GuiUpdateCommand = new RelayCommand(UpdateGUIMethod);
        }

        public ICommand BorrowBookCommand { get; }
        public ICommand ReturnBookCommand { get; }
        public ICommand AddBookCommand { get; }
        public ICommand DeleteBookCommand { get; }
        public ICommand GuiUpdateCommand { get; }

        public ObservableCollection<StateModel> StatesList
        {
            get
            {
                return states;
            }
        }

        public StateModel SelectedState
        {
            get
            {
                return selectedState;
            }
            set
            {
                selectedState = value;
                RaisePropertyChanged("SelectedState");
            }
        }

        public void ReturnBookMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Book returned."));
        }

        public void BorrowBookMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Book borrowed."));
        }

        public void AddBookMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Book added."));
        }

        public void DeleteBookMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Book deleted."));
        }

        public void UpdateGUIMethod()
        {
            states = StateModel.GetStates();
            this.RaisePropertyChanged(() => this.StatesList);
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("GUI updated."));
        }
    }
}
