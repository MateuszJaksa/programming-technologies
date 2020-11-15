using System;
using System.Collections.Generic;
using Data;

namespace Logic
{
    public class DataService
    {
        private readonly DataRepository _repository;

        public DataService(DataRepository repository)
        {
            this._repository = repository;
        }

        #region Catalog
        public void AddCatalog(string author) => _repository.AddCatalog(author);

        public List<Catalog> GetCatalogs() => _repository.GetAllCatalogs();

        public void RemoveCatalog(Catalog C) => _repository.RemoveCatalog(C);
        #endregion

        #region Event
        

        public List<AbstractEvent> GetEvents() => _repository.GetAllEvents();

        public List<AbstractEvent> GetEvents(User user)
        {
            List<AbstractEvent> events = _repository.GetAllEvents();
            List<AbstractEvent> returnedEvents = new List<AbstractEvent>();
            foreach (AbstractEvent currentEvent in events)
            {
                if (currentEvent.User == user)
                    returnedEvents.Add(currentEvent);
            }
            return returnedEvents;
        }

        public List<AbstractEvent> GetEvents(State state)
        {
            List<AbstractEvent> events = _repository.GetAllEvents();
            List<AbstractEvent> returnedEvents = new List<AbstractEvent>();
            foreach (AbstractEvent currentEvent in events)
            {
                if (currentEvent.State == state)
                    returnedEvents.Add(currentEvent);
            }
            return returnedEvents;
        }

        public List<AbstractEvent> GetEventsByTime(DateTime time)
        {
            List<AbstractEvent> events = _repository.GetAllEvents();
            List<AbstractEvent> returnedEvents = new List<AbstractEvent>();
            foreach (AbstractEvent currentEvent in events)
            {
                if (currentEvent.Time == time)
                    returnedEvents.Add(currentEvent);
            }
            return returnedEvents;
        }

        public List<AbstractEvent> GetEventsByTime(DateTime startTime, DateTime endTime)
        {
            List<AbstractEvent> events = _repository.GetAllEvents();
            List<AbstractEvent> returnedEvents = new List<AbstractEvent>();
            foreach (AbstractEvent currentEvent in events)
            {
                if (startTime < currentEvent.Time && currentEvent.Time < endTime)
                    returnedEvents.Add(currentEvent);
            }
            return returnedEvents;
        }

        public void RemoveEvent(AbstractEvent E) => _repository.RemoveEvent(E);
        #endregion

        #region State
        public void AddState(Catalog catalog, string title) => _repository.AddState(catalog, title);

        public List<State> GetStates() => _repository.GetAllStates();

        public List<State> GetStatesByAuthor(string author)
        {
            List<State> states = _repository.GetAllStates();
            List<State> returnedStates = new List<State>();
            foreach (State currentState in states)
            {
                if (currentState.Catalog.Author?.IndexOf(author, StringComparison.OrdinalIgnoreCase) >= 0)
                    returnedStates.Add(currentState);
            }
            return returnedStates;
        }

        public List<State> GetStatesByGenre(string genre)
        {
            List<State> states = _repository.GetAllStates();
            List<State> returnedStates = new List<State>();
            foreach (State currentState in states)
            {
                if (currentState.Catalog.Author?.IndexOf(genre, StringComparison.OrdinalIgnoreCase) >= 0)
                    returnedStates.Add(currentState);
            }
            return returnedStates;
        }

        public void RemoveState(State S) => _repository.RemoveState(S);
        #endregion

        #region User
        public void AddUser(string username) => _repository.AddUser(username);

        public List<User> GetUsers() => _repository.GetAllUsers();

        public void RemoveUser(User U) => _repository.RemoveUser(U);
        #endregion
    }
}
