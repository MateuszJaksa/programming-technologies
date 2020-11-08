using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class DataRepository
    {
        private DataContext _context;

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

        public void RemoveCatalog(string author, string genre)
        {
            foreach (Catalog catalog in _context.catalogs.ToList())
            {
                if (catalog.Author == author && catalog.Genre == genre)
                {
                    _context.catalogs.Remove(catalog);
                }
            }
        }

        public void RemoveAllCatalogs()
        {
            _context.catalogs.Clear();
        }

        public Catalog GetCatalog(string author, string genre)
        {
            foreach (Catalog catalog in _context.catalogs)
            {
                if (catalog.Author == author && catalog.Genre == genre)
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

        public void RemoveEvent(DateTime time, string eventUsername)
        {
            foreach (Event currentEvent in _context.events.ToList())
            {
                if (currentEvent.Time == time && currentEvent.User.Username == eventUsername)
                {
                    _context.events.Remove(currentEvent);
                }
            }
        }

        public void RemoveAllEvents()
        {
            _context.events.Clear();
        }

        public Event GetEvent(DateTime time, string eventUsername)
        {
            foreach (Event currentEvent in _context.events)
            {
                if (currentEvent.Time == time && currentEvent.User.Username == eventUsername)
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

        public void RemoveState(string title)
        {
            foreach (State state in _context.states.ToList())
            {
                if (state.Title == title)
                {
                    _context.states.Remove(state);
                }
            }
        }

        public void RemoveAllStates()
        {
            _context.states.Clear();
        }

        public State GetState(string title)
        {
            foreach (State state in _context.states)
            {
                if (state.Title == title)
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
        public void AddUser(string userName)
        {
            if (GetUser(userName) == null)
            {
                _context.users.Add(new User(userName));
            }
        }

        public void RemoveUser(string userName)
        {
            foreach (User user in _context.users.ToList())
            {
                if (user.Username == userName)
                {
                    _context.users.Remove(user);
                }
            }
        }

        public void RemoveAllUsers()
        {
            _context.users.Clear();
        }

        public User GetUser(string userName)
        {
            foreach (User user in _context.users)
            {
                if (user.Username == userName)
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
