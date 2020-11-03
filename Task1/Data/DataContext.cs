using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext
    {
        private static DataContext _instance;

        public List<Catalog> catalogs = new List<Catalog>();
        public List<Event> events = new List<Event>();
        public List<State> states = new List<State>();
        public List<User> users = new List<User>();

        private DataContext() { }

        public static DataContext getRepositoryInstance()
        {
            if (_instance == null)
            {
                _instance = new DataContext();
            }
            return _instance;
        }
    }
}
