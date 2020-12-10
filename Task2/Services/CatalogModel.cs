using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Services
{
    public class CatalogModel : ObservableObject
    {
        private string title;
        private string author;
        private ObservableCollection<StateModel> states;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
            }
        }
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
            }
        }
    }
}
