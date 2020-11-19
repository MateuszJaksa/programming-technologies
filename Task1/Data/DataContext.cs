using System.Collections.Generic;

namespace Data
{
    public class DataContext : IDataContext
    {
        private IList<ICatalog> catalogs = new List<ICatalog>();
        private IList<AbstractEvent> events = new List<AbstractEvent>();
        private IList<IState> states = new List<IState>();
        private IList<IUser> users = new List<IUser>();

        public DataContext() { }

        public IList<ICatalog> GetCatalogs()
        {
            return catalogs;
        }

        public IList<AbstractEvent> GetEvents()
        {
            return events;
        }

        public IList<IState> GetStates()
        {
            return states;
        }

        public IList<IUser> GetUsers()
        {
            return users;
        }
    }
}
