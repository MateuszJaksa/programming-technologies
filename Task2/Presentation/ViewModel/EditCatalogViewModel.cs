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
    public class EditCatalogViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly LibraryRepository repository = new LibraryRepository();
        private string id;
        private string title;
        private string author;

        public string Id
        {
            get { return id; }
            set { Set<string>(() => this.Id, ref id, value); }
        }

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

        public ICommand EditCatalogCommand { get; private set; }

        public string Error => throw new Exception();

        public EditCatalogViewModel() : base()
        {
            EditCatalogCommand = new RelayCommand(EditCatalogMethod);
        }

        public void EditCatalogMethod()
        {
            Task.Run(() => {
                repository.UpdateCatalog(int.Parse(id), Title, Author);
                
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage("RefreshCatalog"));
            });
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("CloseEditCatalog"));
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                List<int> availableIds = repository.GetAllCatalogIds();
                switch (columnName)
                {
                    case "Id": if (string.IsNullOrEmpty(Id)) return "CatalogId cannot be empty!"; if (!Int32.TryParse(Id, out int parsedInt)) return "That is not number value"; if (!availableIds.Contains(parsedInt)) return "That is not a proper Catalog ID"; break;
                    case "Title": if (string.IsNullOrEmpty(title)) return "Title cannot be empty!"; if (title.Length > 64) return "Title cannot be that long"; break;
                    case "Author": if (string.IsNullOrEmpty(author)) return "Author cannot be empty!"; if (author.Length > 64) return "Author cannot be that long"; break;
                };
                return null;
            }
        }


    }
}
