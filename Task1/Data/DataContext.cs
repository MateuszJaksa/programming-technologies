using System.Collections.Generic;

namespace Data
{
    public class DataContext : IDataContext
    {
        public DataContext()
        {
            Catalogs = new List<ICatalog>();
            Events = new List<AbstractEvent>();
            States = new List<IState>();
            Users = new List<IUser>();
    }

        public IList<ICatalog> Catalogs { get; }

        public IList<AbstractEvent> Events { get; }

        public IList<IState> States { get; }

        public IList<IUser> Users { get; }
    }
}
