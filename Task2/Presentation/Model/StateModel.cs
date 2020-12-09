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
        public int ID { get; set; }
        public bool IsBorrowed { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public static ObservableCollection<StateModel> GetStates()
        {
            ObservableCollection<StateModel> states = new ObservableCollection<StateModel>();
            for (int i = 0; i < 30; ++i)
            {
                states.Add(new StateModel
                {
                    ID = i + 1,
                    IsBorrowed = false,
                    Title = "Bible",
                    Author = "Hesus"
                });
            }
            return states;
        }
    }
}
