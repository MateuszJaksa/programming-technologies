using System.Collections.Generic;

namespace Data
{
    public class DataContext
    {
        public ICollection<Catalog> catalogs = new List<Catalog>();
        public ICollection<Event> events = new List<Event>();
        public ICollection<State> states = new List<State>();
        public ICollection<User> users = new List<User>();

        public DataContext() { }
    }
}
