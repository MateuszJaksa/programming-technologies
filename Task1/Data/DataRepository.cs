using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class DataRepository
    {
        private readonly DataContext _context;

        public DataRepository(DataContext context)
        {
            this._context = context;
        }

        public void AddCatalog(string author, string genre)
        {
            if (GetCatalog(author, genre) == null)
            {
                _context.catalogs.Add(new Catalog(author, genre));
            }
        }

        public void RemoveCatalog(Catalog catalog)
        {
            _context.catalogs.Remove(catalog);
        }

        public void RemoveAllCatalogs()
        {
            _context.catalogs.Clear();
        }

        public Catalog GetCatalog(string author, string genre)
        {
            Catalog testCatalog = new Catalog(author, genre);
            foreach (Catalog catalog in _context.catalogs.ToList())
            {
                if (testCatalog.Equals(catalog))
                {
                    return catalog;
                }
            }
            return null;
        }
        public List<Catalog> GetAllCatalogs()
        {
            return new List<Catalog>(_context.catalogs);
        }

        public void AddEvent(State state, User user, DateTime time)
        {
            if (GetEvent(time, user.Username) == null)
            {
                _context.events.Add(new Event(state, user, time));
            }
        }

        public void RemoveEvent(Event removedEvent)
        {
            _context.events.Remove(removedEvent);
        }

        public void RemoveAllEvents()
        {
            _context.events.Clear();
        }

        public Event GetEvent(DateTime time, string eventUsername)
        {
            Event testEvent = new Event(new State(new Catalog(null, null), null), new User(eventUsername), time);
            foreach (Event currentEvent in _context.events.ToList())
            {
                if (testEvent.Equals(currentEvent))
                {
                    return currentEvent;
                }
            }
            return null;
        }

        public List<Event> GetAllEvents()
        {
            return new List<Event>(_context.events);
        }

        public void AddState(Catalog catalog, string title)
        {
            if (GetState(title) == null)
            {
                _context.states.Add(new State(catalog, title));
            }
        }

        public void RemoveState(State state)
        {
            _context.states.Remove(state);
        }

        public void RemoveAllStates()
        {
            _context.states.Clear();
        }

        public State GetState(string title)
        {
            State testState = new State(new Catalog(null, null), title);
            foreach (State state in _context.states.ToList())
            {
                if (testState.Equals(state))
                {
                    return state;
                }
            }
            return null;
        }

        public List<State> GetAllStates()
        {
            return new List<State>(_context.states);
        }
        public void AddUser(string username)
        {
            if (GetUser(username) == null)
            {
                _context.users.Add(new User(username));
            }
        }

        public void RemoveUser(User user)
        {
            _context.users.Remove(user);
        }

        public void RemoveAllUsers()
        {
            _context.users.Clear();
        }

        public User GetUser(string username)
        {
            User testUser = new User(username);
            foreach (User user in _context.users.ToList())
            {
                if (testUser.Equals(user))
                {
                    return user;
                }
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            return new List<User>(_context.users);
        }
    }
}
