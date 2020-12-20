using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Presentation.Model
{
    public class StateModel : ObservableObject
    {
        private int id;
        private bool isBorrowed;
        private int catalogId;

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
            ObservableCollection<StateModel> states = new ObservableCollection<StateModel>();
            for (int i = 0; i < 3; i++)
            {
                states.Add(new StateModel
                {
                    Id = i + 1,
                    IsBorrowed = true,
                    CatalogId = i
                });

            }
            return states;

        }
    }
}
