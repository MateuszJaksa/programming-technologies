using System.Collections.Generic;

namespace Data
{
    public interface IDataContext
    {
        IList<ICatalog> GetCatalogs();

        IList<AbstractEvent> GetEvents();

        IList<IState> GetStates();

        IList<IUser> GetUsers();
    }
}
