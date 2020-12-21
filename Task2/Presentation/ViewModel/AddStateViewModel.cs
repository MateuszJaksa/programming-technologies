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
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                LibraryRepository repository = new LibraryRepository();
                List<int> availableIds = new List<int>();
                Task.Run(() => availableIds = repository.GetAllCatalogIds());
                switch (columnName)
                {
                    case "Title": if (string.IsNullOrEmpty(isBorrowed)) result = "IsBorrowed cannot be empty!"; if (!bool.Parse(isBorrowed)) result = "That is not true value"; break;
                    case "Author": if (string.IsNullOrEmpty(catalogId)) result = "CatalogId cannot be empty!"; if (!availableIds.Contains(int.Parse(catalogId))) result = "That is not available id"; break;
                };
                return result;
            }
        }
    }
}
