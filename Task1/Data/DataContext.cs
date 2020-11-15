using System.Collections.Generic;

namespace Data
{
    public class DataContext
    {
        public IList<Catalog> catalogs = new List<Catalog>();
        public IList<AbstractEvent> events = new List<AbstractEvent>();
        public IList<State> states = new List<State>();
        public IList<User> users = new List<User>();

        public DataContext() { }
    }
}
