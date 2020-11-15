using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDataRepository
    {
        void Fill();

        void AddCatalog(string author);

        void RemoveCatalog(Catalog catalog);

        void RemoveAllCatalogs();

        Catalog GetCatalog(string author);

        List<Catalog> GetAllCatalogs();

        int GetCatalogsNumber();

        void AddBorrowEvent(State state, User user, DateTime time);
        void AddReturnEvent(State state, User user, DateTime time);

        void RemoveEvent(AbstractEvent removedEvent);

        void RemoveAllEvents();

        AbstractEvent GetEvent(DateTime time, string eventUsername);

        List<AbstractEvent> GetAllEvents();

        int GetEventsNumber();

        void AddState(Catalog catalog, string title);

        void RemoveState(State state);

        void RemoveAllStates();

        State GetState(string title);

        List<State> GetAllStates();

        int GetStatesNumber();

        void AddUser(string username);

        void RemoveUser(User user);

        void RemoveAllUsers();

        User GetUser(string username);

        List<User> GetAllUsers();

        int GetUsersNumber();
    }
}
