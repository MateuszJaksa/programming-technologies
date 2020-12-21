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
    public class AddCatalogViewModel : ViewModelBase, IDataErrorInfo
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

        public AddCatalogViewModel() : base()
        {
            SaveCatalogCommand = new RelayCommand(SaveCatalogMethod);
        }

        public void SaveCatalogMethod()
        {
            LibraryRepository repository = new LibraryRepository();
            Task.Run(() => repository.AddCatalog(Title, Author));
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("CloseAddCatalog"));
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                string result = string.Empty;
                switch (columnName)
                {
                    case "Title": if (string.IsNullOrEmpty(title)) result = "Title cannot be empty!"; if (title != null && title.Length > 64) result = "Title cannot be that long"; break;
                    case "Author": if (string.IsNullOrEmpty(author)) result = "Author cannot be empty!"; if (author != null && author.Length > 64) result = "Author cannot be that long"; break;
                };
                return result;
            }
        }


    }
}
