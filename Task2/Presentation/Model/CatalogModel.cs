using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Services;

namespace Presentation.Model
{
    public class CatalogModel : ObservableObject
    {
        private int id;
        private string title;
        private string author;
        private readonly static LibraryRepository repository = new LibraryRepository();
        static ObservableCollection<CatalogModel> models;

        public CatalogModel(int id, string title, string author)
        {
            this.id = id;
            this.title = title;
            this.author = author;
        }

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
            List<int> catalogIDs = new List<int>();
            catalogIDs = repository.GetAllCatalogIds();
            models = new ObservableCollection<CatalogModel>();
            foreach (int id in catalogIDs)
            {
                models.Add(new CatalogModel(id, repository.GetCatalogTitle(id), repository.GetCatalogAuthor(id)));
            }
            return models;
        }
    }
}
