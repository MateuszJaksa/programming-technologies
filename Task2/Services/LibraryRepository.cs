using System;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Services
{
    public class LibraryRepository
    {
        private readonly LinqToSqlDataContext dataContext = new LinqToSqlDataContext();

        public LibraryRepository()
        {
            
        }

        public int AddCatalog(string title, string author)
        {
            Catalogs newCatalog = new Catalogs
            {
                Title = title,
                Author = author
            };
            dataContext.Catalogs.InsertOnSubmit(newCatalog);
            dataContext.SubmitChanges();
            return newCatalog.ID;
        }

        public void UpdateCatalog(int id, string title, string author)
        {
            Catalogs updatedCatalog = dataContext.Catalogs.FirstOrDefault(catalog => catalog.ID == id);
            updatedCatalog.Title = title;
            updatedCatalog.Author = author;
            dataContext.SubmitChanges();
        }

        public void RemoveCatalog(int id)
        {
            bool canBeRemoved = true;
            foreach (States states in dataContext.States.ToList())
            {
                if (states.CatalogId == id) { canBeRemoved = false; }
            }
            if (canBeRemoved)
            {
                Catalogs removedCatalog = dataContext.Catalogs.FirstOrDefault(catalog => catalog.ID == id);
                dataContext.Catalogs.DeleteOnSubmit(removedCatalog);
                dataContext.SubmitChanges();
            }
        }

        public void RemoveAllCatalogs()
        {
            dataContext.ExecuteCommand(@"DELETE FROM Catalogs;");
        }

        public string GetCatalogTitle(int id)
        {
            return dataContext.Catalogs.FirstOrDefault(catalog => catalog.ID == id).Title;
        }

        public string GetCatalogAuthor(int id)
        {
            return dataContext.Catalogs.FirstOrDefault(catalog => catalog.ID == id).Author;
        }

        public List<int> GetAllCatalogIds()
        {
            List<int> returnedList = new List<int>();
            foreach (Catalogs catalogs in dataContext.Catalogs.ToList())
            {
                returnedList.Add(catalogs.ID);
            }
            return returnedList;
        }

        public int AddState(int catalogId, bool isBorrowed)
        {
            States newState = new States
            {
                IsBorrowed = isBorrowed,
                CatalogId = catalogId
            };
            dataContext.States.InsertOnSubmit(newState);
            dataContext.SubmitChanges();
            return newState.ID;
        }

        public void UpdateState(int id, int catalogId, bool isBorrowed)
        {
            States updatedState = dataContext.States.FirstOrDefault(state => state.ID == id);
            updatedState.CatalogId = catalogId;
            updatedState.IsBorrowed = isBorrowed;
            dataContext.SubmitChanges();
        }

        public void RemoveState(int id)
        {
            States removedState = dataContext.States.FirstOrDefault(state => state.ID == id);
            dataContext.States.DeleteOnSubmit(removedState);
            dataContext.SubmitChanges();
        }

        public void RemoveAllStates()
        {
            dataContext.ExecuteCommand(@"DELETE FROM States;");
        }

        public bool GetStateIsBorrowed(int id)
        {
            return (bool)dataContext.States.FirstOrDefault(state => state.ID == id).IsBorrowed;
        }

        public int GetStateCatalogId(int id)
        {
            return (int)dataContext.States.FirstOrDefault(state => state.ID == id).CatalogId;
        }

        public List<int> GetAllStateIds()
        {
            List<int> returnedList = new List<int>();
            foreach (States state in dataContext.States.ToList())
            {
                returnedList.Add(state.ID);
            }
            return returnedList;
        }
    }
}
