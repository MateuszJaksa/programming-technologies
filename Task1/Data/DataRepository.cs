using System;
using System.Collections.Generic;
using System.Linq;
using Generation;

namespace Data
{
    public class DataRepository : IDataRepository
    {
        private readonly DataContext _context = new DataContext();
        private readonly IGeneration _generation;

        public DataRepository(IGeneration generation)
        {
            _generation = generation;
        }

        public void Fill()
        {
            _generation.Fill(_context);
        }

        public void AddCatalog(string author)
        {
            if (GetCatalog(author) == null)
            {
                _context.catalogs.Add(new Catalog(author));
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

        public Catalog GetCatalog(string author)
        {
            Catalog testCatalog = new Catalog(author);
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
            if (GetCatalogsNumber() != 0)
            {
                return new List<Catalog>(_context.catalogs);
            }
            return null;
        }

        public int GetCatalogsNumber()
        {
            return _context.catalogs.Count();
        }

        public void AddBorrowEvent(State state, User user, DateTime time)
        {
            _context.events.Add(new BorrowEvent(state, user, time));
        }

        public void AddReturnEvent(State state, User user, DateTime time)
        {
            _context.events.Add(new ReturnEvent(state, user, time));
        }

        public void RemoveEvent(AbstractEvent removedEvent)
        {
            _context.events.Remove(removedEvent);
        }

        public void RemoveAllEvents()
        {
            _context.events.Clear();
        }

        public AbstractEvent GetEvent(DateTime time, string eventUsername)
        {
            foreach (AbstractEvent currentEvent in _context.events.ToList())
            {
                if (currentEvent.Time == time && currentEvent.User.Username ==  eventUsername)
                {
                    return currentEvent;
                }
            }
            return null;
        }

        public List<AbstractEvent> GetAllEvents()
        {
            if (GetEventsNumber() != 0)
            {
                return new List<AbstractEvent>(_context.events);
            }
            return null;
        }

        public int GetEventsNumber()
        {
            return _context.events.Count();
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
            foreach (State state in _context.states.ToList())
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
            if (GetStatesNumber() != 0)
            {
                return new List<State>(_context.states);
            }
            return null;
        }

        public int GetStatesNumber()
        {
            return _context.states.Count();
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
            if (GetUsersNumber() != 0)
            {
                return new List<User>(_context.users);
            }
            return null;
        }

        public int GetUsersNumber()
        {
            return _context.users.Count();
        }
    }
}
