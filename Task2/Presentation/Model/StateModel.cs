using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Services;

namespace Presentation.Model
{
    public class StateModel : ObservableObject
    {
        private int id;
        private bool isBorrowed;
        private int catalogId;
        private readonly static LibraryRepository repository = new LibraryRepository();

        public StateModel(int id, bool isBorrowed, int catalogId)
        {
            this.id = id;
            this.isBorrowed = isBorrowed;
            this.catalogId = catalogId;
        }

        public int Id
        {
            get { return id; }
            set { Set<int>(() => this.Id, ref id, value); }
        }
        public bool IsBorrowed
        {
            get { return isBorrowed; }
            set { Set<bool>(() => this.IsBorrowed, ref isBorrowed, value); }
        }
        public int CatalogId
        {
            get { return catalogId; }
            set { Set<int>(() => this.CatalogId, ref catalogId, value); }
        }

        public static ObservableCollection<StateModel> GetStates()
        {
            ObservableCollection<StateModel> models = new ObservableCollection<StateModel>();
            List<int> stateIDs = new List<int>();
            stateIDs = repository.GetAllStateIds();
            foreach (int id in stateIDs)
            {
                models.Add(new StateModel(id, repository.GetStateIsBorrowed(id), repository.GetStateCatalogId(id)));
            }
            return models;

        }
    }
}
