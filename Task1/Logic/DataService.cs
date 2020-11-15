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
        public void AddCatalog(string author) => _repository.AddCatalog(author);

        public IList<Catalog> GetCatalogs() => _repository.GetAllCatalogs();

        public IList<Catalog> GetCatalogs(string author)
        {
            IList<Catalog> catalogs = _repository.GetAllCatalogs();
            IList<Catalog> returnedCatalogs = new List<Catalog>();
            foreach (Catalog currentCatalog in catalogs)
            {
                if (currentCatalog.Author?.IndexOf(author, StringComparison.OrdinalIgnoreCase) >= 0)
                    returnedCatalogs.Add(currentCatalog);
            }
            return returnedCatalogs;
        }

        public void RemoveCatalog(Catalog C) => _repository.RemoveCatalog(C);
        #endregion

        #region Event  

        public void Borrow(State state, User user) => _repository.AddBorrowEvent(state, user, DateTime.Now);

        public void Return(State state, User user) => _repository.AddReturnEvent(state, user, DateTime.Now);

        public IList<AbstractEvent> GetEvents() => _repository.GetAllEvents();

        public IList<AbstractEvent> GetEvents(User user)
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

        public IList<AbstractEvent> GetEvents(State state)
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

        public IList<AbstractEvent> GetEventsByTime(State state, DateTime startTime, DateTime endTime)
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
        public void AddState(Catalog catalog, string title) => _repository.AddState(catalog, title);

        public IList<State> GetStates() => _repository.GetAllStates();

        public IList<State> GetStates(string title)
        {
            IList<State> states = _repository.GetAllStates();
            IList<State> returnedStates = new List<State>();
            foreach (State currentState in states)
            {
                if (currentState.Title?.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
                    returnedStates.Add(currentState);
            }
            return returnedStates;
        }

        public IList<State> SearchStatesByAuthor(string author)
        {
            IList<State> states = _repository.GetAllStates();
            IList<State> returnedStates = new List<State>();
            foreach (State currentState in states)
            {
                if (currentState.Catalog.Author?.IndexOf(author, StringComparison.OrdinalIgnoreCase) >= 0)
                    returnedStates.Add(currentState);
            }
            return returnedStates;
        }

        public IList<State> GetAvailableStates()
        {
            IList<State> states = _repository.GetAllStates();
            IList<State> returnedStates = new List<State>();
            foreach (State currentState in states)
            {
                if (!currentState.IsBorrowed)
                    returnedStates.Add(currentState);
            }
            return returnedStates;
        }

        public void RemoveState(State S) => _repository.RemoveState(S);
        #endregion

        #region User
        public void AddUser(string username) => _repository.AddUser(username);

        public IList<User> GetUsers() => _repository.GetAllUsers();

        public IList<User> GetUsers(string username)
        {
            IList<User> users = _repository.GetAllUsers();
            IList<User> returnedUsers = new List<User>();
            foreach (User currentUser in users)
            {
                if (currentUser.Username?.IndexOf(username, StringComparison.OrdinalIgnoreCase) >= 0)
                    returnedUsers.Add(currentUser);
            }
            return returnedUsers;
        }

        public void RemoveUser(User U) => _repository.RemoveUser(U);
        #endregion
    }
}
