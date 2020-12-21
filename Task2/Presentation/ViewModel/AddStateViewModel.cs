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
        private string isBorrowed;
        private string catalogId;

        public string IsBorrowed
        {
            get { return isBorrowed; }
            set { Set<string>(() => this.IsBorrowed, ref isBorrowed, value); }
        }
        public string CatalogId
        {
            get { return catalogId; }
            set { Set<string>(() => this.CatalogId, ref catalogId, value); }
        }

        public ICommand SaveStateCommand { get; private set; }

        public string Error => throw new Exception();

        public AddStateViewModel() : base()
        {
            SaveStateCommand = new RelayCommand(SaveStateMethod);
        }

        public void SaveStateMethod()
        {
            LibraryRepository repository = new LibraryRepository();
            Task.Run(() => repository.AddState(int.Parse(CatalogId), bool.Parse(IsBorrowed)));
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("CloseAddState"));
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("RefreshState"));
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                LibraryRepository repository = new LibraryRepository();
                List<int> availableIds = repository.GetAllCatalogIds();
                switch (columnName)
                {
                    case "IsBorrowed": if (string.IsNullOrEmpty(isBorrowed)) result = "IsBorrowed cannot be empty!"; if (isBorrowed != null && !bool.TryParse(isBorrowed, out bool parsedBool)) result = "That is not true value"; break;
                    case "CatalogId": if (string.IsNullOrEmpty(catalogId)) result = "CatalogId cannot be empty!"; break;
                };
                return result;
            }
        }
    }
}
