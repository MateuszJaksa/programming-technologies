using System;
using System.Collections.Generic;
using Data;

namespace Logic
{
    public class DataService
    {
        private readonly IDataRepository _repository;

        public DataService(IDataRepository repository)
        {
            this._repository = repository;
        }

        #region Catalog
        public void AddCatalog(string title, string author) => _repository.AddCatalog(title, author);

        public IList<ICatalog> GetCatalogs() => _repository.GetAllCatalogs();

        public IList<ICatalog> GetCatalogs(string author)
        {
            IList<ICatalog> catalogs = _repository.GetAllCatalogs();
            IList<ICatalog> returnedCatalogs = new List<ICatalog>();
            foreach (ICatalog currentCatalog in catalogs)
            {
                if (currentCatalog.Author?.IndexOf(author, StringComparison.OrdinalIgnoreCase) >= 0)
                    returnedCatalogs.Add(currentCatalog);
            }
            return returnedCatalogs;
        }

        public void RemoveCatalog(ICatalog C) => _repository.RemoveCatalog(C);
        #endregion

        #region Event  

        public void Borrow(IState state, IUser user) => _repository.AddBorrowEvent(state, user, DateTime.Now);

        public void Return(IState state, IUser user) => _repository.AddReturnEvent(state, user, DateTime.Now);

        public IList<AbstractEvent> GetEvents() => _repository.GetAllEvents();

        public IList<AbstractEvent> GetEvents(IUser user)
        {
            IList<AbstractEvent> events = _repository.GetAllEvents();
            IList<AbstractEvent> returnedEvents = new List<AbstractEvent>();
            foreach (AbstractEvent currentEvent in events)
            {
                if (currentEvent.User == user)
                    returnedEvents.Add(currentEvent);
            }
            return returnedEvents;
        }

        public IList<AbstractEvent> GetEvents(IState state)
        {
            IList<AbstractEvent> events = _repository.GetAllEvents();
            IList<AbstractEvent> returnedEvents = new List<AbstractEvent>();
            foreach (AbstractEvent currentEvent in events)
            {
                if (currentEvent.State == state)
                    returnedEvents.Add(currentEvent);
            }
            return returnedEvents;
        }

        public IList<AbstractEvent> GetEventsByTime(DateTime startTime, DateTime endTime)
        {
            IList<AbstractEvent> events = _repository.GetAllEvents();
            IList<AbstractEvent> returnedEvents = new List<AbstractEvent>();
            foreach (AbstractEvent currentEvent in events)
            {
                if (startTime < currentEvent.Time && currentEvent.Time < endTime)
                    returnedEvents.Add(currentEvent);
            }
            return returnedEvents;
        }

        public IList<AbstractEvent> GetEventsByTime(IState state, DateTime startTime, DateTime endTime)
        {
            IList<AbstractEvent> events = _repository.GetAllEvents();
            IList<AbstractEvent> returnedEvents = new List<AbstractEvent>();
            foreach (AbstractEvent currentEvent in events)
            {
                if (startTime < currentEvent.Time && currentEvent.Time < endTime  && currentEvent.State == state)
                    returnedEvents.Add(currentEvent);
            }
            return returnedEvents;
        }

        #endregion

        #region State
        public void AddState(ICatalog catalog, int id) => _repository.AddState(catalog, id);

        public IList<IState> GetStates() => _repository.GetAllStates();

        public IList<IState> GetStates(int id)
        {
            IList<IState> states = _repository.GetAllStates();
            IList<IState> returnedStates = new List<IState>();
            foreach (IState currentState in states)
            {
                if (currentState.ID == id)
                    returnedStates.Add(currentState);
            }
            return returnedStates;
        }

        public IList<IState> SearchStatesByAuthor(string author)
        {
            IList<IState> states = _repository.GetAllStates();
            IList<IState> returnedStates = new List<IState>();
            foreach (IState currentState in states)
            {
                if (currentState.Catalog.Author?.IndexOf(author, StringComparison.OrdinalIgnoreCase) >= 0)
                    returnedStates.Add(currentState);
            }
            return returnedStates;
        }

        public IList<IState> GetAvailableStates()
        {
            IList<IState> states = _repository.GetAllStates();
            IList<IState> returnedStates = new List<IState>();
            foreach (IState currentState in states)
            {
                if (!currentState.IsBorrowed)
                    returnedStates.Add(currentState);
            }
            return returnedStates;
        }

        public void RemoveState(IState S) => _repository.RemoveState(S);
        #endregion

        #region User
        public void AddUser(string username) => _repository.AddUser(username);

        public IList<IUser> GetUsers() => _repository.GetAllUsers();

        public IList<IUser> GetUsers(string username)
        {
            IList<IUser> users = _repository.GetAllUsers();
            IList<IUser> returnedUsers = new List<IUser>();
            foreach (IUser currentUser in users)
            {
                if (currentUser.Username?.IndexOf(username, StringComparison.OrdinalIgnoreCase) >= 0)
                    returnedUsers.Add(currentUser);
            }
            return returnedUsers;
        }

        public void RemoveUser(IUser U) => _repository.RemoveUser(U);
        #endregion
    }
}
