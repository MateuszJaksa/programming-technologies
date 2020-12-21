using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Services;

namespace Presentation.ViewModel
{
    public class AddStateViewModel : ViewModelBase, IDataErrorInfo
    {
        private bool isBorrowed;
        private int catalogId;

        public bool IsBorrowed
        {
            get { return isBorrowed; }
            set { Set<bool>(() => this.IsBorrowed, ref isBorrowed, value); }
        }
        public int CatalogId
        {
            get { return catalogId; }
            set { Set<int>(() => this.CatalogId, ref catalogId, value); }
        }

        public ICommand SaveStateCommand { get; private set; }

        public string Error => throw new Exception();

        public string this[string columnName] => throw new NotImplementedException();

        public AddStateViewModel() : base()
        {
            SaveStateCommand = new RelayCommand(SaveStateMethod);
        }

        public void SaveStateMethod()
        {
            LibraryRepository repository = new LibraryRepository();
            repository.AddState(CatalogId, IsBorrowed);
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("CloseAddState"));
        }

    }
}
