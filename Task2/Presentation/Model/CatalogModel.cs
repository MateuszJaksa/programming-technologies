using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Presentation.Model
{
    public class CatalogModel : ObservableObject
    {
        private int id;
        private string title;
        private string author;

        public int Id
        {
            get { return id; }
            set { Set<int>(() => this.Id, ref id, value); }
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

        public static ObservableCollection<CatalogModel> GetCatalogs()
        {
            ObservableCollection<CatalogModel> catalogs = new ObservableCollection<CatalogModel>();
            for (int i = 0; i < 3; i++)
            {
                catalogs.Add(new CatalogModel
                {
                    Id = i + 1,
                    Title = "Title" + i.ToString(),
                    Author = "XD"
                });

            }
            return catalogs;
        }
    }
}
