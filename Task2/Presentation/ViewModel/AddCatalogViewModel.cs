using System;
using System.Collections.Generic;
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
    public class AddCatalogViewModel : ViewModelBase
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

        public AddCatalogViewModel() : base()
        {
            SaveCatalogCommand = new RelayCommand(SaveCatalogMethod);
        }

        public void SaveCatalogMethod()
        {
            LibraryRepository repository = new LibraryRepository();
            repository.AddCatalog(Title, Author);
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("CloseAddCatalog"));
        }
    }
}
