using System.Collections.Generic;

namespace Data
{
    public class DataContext
    {
        public List<Catalog> catalogs = new List<Catalog>();
        public List<Event> events = new List<Event>();
        public List<State> states = new List<State>();
        public List<User> users = new List<User>();

        public DataContext() { }
    }
}
