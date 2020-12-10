using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Data;

namespace Services
{
    public class Service
    {
        private DataRepository repository;
        private ObservableCollection<CatalogModel> catalogs;

        public Service()
        {
            repository = new DataRepository();
        }

        public void AddCatalog(CatalogModel catalogModel)
        {
            repository.AddCatalog(catalogModel.Title, catalogModel.Author);
        }

        public List<Catalog> GetCatalogs()
        {
            return repository.GetAllCatalogs();
        }
    }
}
