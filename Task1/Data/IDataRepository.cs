using System;
using System.Collections.Generic;

namespace Data
{
    public interface IDataRepository
    {
        void Fill();

        void AddCatalog(string title, string author);

        void RemoveCatalog(ICatalog catalog);

        void RemoveAllCatalogs();

        ICatalog GetCatalog(string title, string author);

        List<ICatalog> GetAllCatalogs();

        int GetCatalogsNumber();

        void AddBorrowEvent(IState state, IUser user, DateTime time);
        void AddReturnEvent(IState state, IUser user, DateTime time);

        void RemoveEvent(AbstractEvent removedEvent);

        void RemoveAllEvents();

        AbstractEvent GetEvent(DateTime time, string eventUsername);

        List<AbstractEvent> GetAllEvents();

        int GetEventsNumber();

        void AddState(ICatalog catalog, int id);

        void RemoveState(IState state);

        void RemoveAllStates();

        IState GetState(int id);

        List<IState> GetAllStates();

        int GetStatesNumber();

        void AddUser(string username);

        void RemoveUser(IUser user);

        void RemoveAllUsers();

        IUser GetUser(string username);

        List<IUser> GetAllUsers();

        int GetUsersNumber();
    }
}
