using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Services;

namespace Presentation.ViewModel
{
    public class AddEditStateViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly LibraryRepository repository = new LibraryRepository();
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

        public AddEditStateViewModel() : base()
        {
            SaveStateCommand = new RelayCommand(SaveStateMethod);
        }

        public void SaveStateMethod()
        {
            Task.Run(() => repository.AddState(int.Parse(CatalogId), bool.Parse(IsBorrowed)));
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("CloseAddState"));
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("RefreshState"));
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                List<int> availableIds = repository.GetAllCatalogIds();
                switch (columnName)
                {
                    case "IsBorrowed": if (string.IsNullOrEmpty(isBorrowed)) return "IsBorrowed cannot be empty!"; if (!bool.TryParse(isBorrowed, out bool parsedBool)) return "That is not boolean value"; break;
                    case "CatalogId": if (string.IsNullOrEmpty(catalogId)) return "CatalogId cannot be empty!"; if (!Int32.TryParse(catalogId, out int parsedInt)) return "That is not number value"; if (!availableIds.Contains(parsedInt)) return "That is not a proper Catalog ID"; break;
                };
                return null;
            }
        }
    }
}
