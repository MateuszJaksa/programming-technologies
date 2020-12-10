using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Services
{
    public class StateModel : ObservableObject
    {
        private int id;
        private bool isBorrowed;

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public bool IsBorrowed
        {
            get { return isBorrowed; }
            set
            {
                isBorrowed = value;
            }
        }
    }
}
