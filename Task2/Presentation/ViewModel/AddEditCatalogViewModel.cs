using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Services;

namespace Presentation.ViewModel
{
    public class AddEditCatalogViewModel : ViewModelBase, IDataErrorInfo
    {
        private string title;
        private string author;

        public string Title
        {
            get { return title; }
            set { Set<string>(() => this.Title, ref title, value); }
        }
        public string Author
        {
            get { return author; }
            set { Set<string>(() => this.Author, ref author, value); }
        }

        public ICommand SaveCatalogCommand { get; private set; }

        public string Error => throw new Exception();

        public AddEditCatalogViewModel() : base()
        {
            SaveCatalogCommand = new RelayCommand(SaveCatalogMethod);
        }

        public void SaveCatalogMethod()
        {
            LibraryRepository repository = new LibraryRepository();
            Task.Run(() => repository.AddCatalog(Title, Author));
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("CloseAddCatalog"));
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("RefreshCatalog"));
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Title": if (string.IsNullOrEmpty(title)) return "Title cannot be empty!"; if (title.Length > 64) return "Title cannot be that long"; break;
                    case "Author": if (string.IsNullOrEmpty(author)) return "Author cannot be empty!"; if (author.Length > 64) return "Author cannot be that long"; break;
                };
                return null;
            }
        }


    }
}
