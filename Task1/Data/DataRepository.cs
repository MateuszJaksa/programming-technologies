using System;
using System.Collections.Generic;
using System.Linq;
using Generation;

namespace Data
{
    public class DataRepository : IDataRepository
    {
        private readonly IDataContext _context = new DataContext();
        private readonly IGeneration _generation;

        public DataRepository(IGeneration generation)
        {
            _generation = generation;
        }

        public void Fill()
        {
            _generation.Fill(_context);
        }

        public void AddCatalog(string title, string author)
        {
            if (GetCatalog(title, author) == null)
            {
                _context.GetCatalogs().Add(new Catalog(title, author));
            }
        }

        public void RemoveCatalog(ICatalog catalog)
        {
            _context.GetCatalogs().Remove(catalog);
        }

        public void RemoveAllCatalogs()
        {
            _context.GetCatalogs().Clear();
        }

        public ICatalog GetCatalog(string title, string author)
        {
            foreach (ICatalog catalog in _context.GetCatalogs().ToList())
            {
                if (catalog.Title == title && catalog.Author == author)
                {
                    return catalog;
                }
            }
            return null;
        }
        public List<ICatalog> GetAllCatalogs()
        {
            if (GetCatalogsNumber() != 0)
            {
                return new List<ICatalog>(_context.GetCatalogs());
            }
            return null;
        }

        public int GetCatalogsNumber()
        {
            return _context.GetCatalogs().Count();
        }

        public void AddBorrowEvent(IState state, IUser user, DateTime time)
        {
            _context.GetEvents().Add(new BorrowEvent(state, user, time));
        }

        public void AddReturnEvent(IState state, IUser user, DateTime time)
        {
            _context.GetEvents().Add(new ReturnEvent(state, user, time));
        }

        public void RemoveEvent(AbstractEvent removedEvent)
        {
            _context.GetEvents().Remove(removedEvent);
        }

        public void RemoveAllEvents()
        {
            _context.GetEvents().Clear();
        }

        public AbstractEvent GetEvent(DateTime time, string eventUsername)
        {
            foreach (AbstractEvent currentEvent in _context.GetEvents().ToList())
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
                return new List<AbstractEvent>(_context.GetEvents());
            }
            return null;
        }

        public int GetEventsNumber()
        {
            return _context.GetEvents().Count();
        }

        public void AddState(ICatalog catalog, int id)
        {
            if (GetState(id) == null)
            {
                _context.GetStates().Add(new State(catalog, id));
            }
        }

        public void RemoveState(IState state)
        {
            _context.GetStates().Remove(state);
        }

        public void RemoveAllStates()
        {
            _context.GetStates().Clear();
        }

        public IState GetState(int id)
        {
            foreach (IState state in _context.GetStates().ToList())
            {
                if (state.ID == id)
                {
                    return state;
                }
            }
            return null;
        }

        public List<IState> GetAllStates()
        {
            if (GetStatesNumber() != 0)
            {
                return new List<IState>(_context.GetStates());
            }
            return null;
        }

        public int GetStatesNumber()
        {
            return _context.GetStates().Count();
        }

        public void AddUser(string username)
        {
            if (GetUser(username) == null)
            {
                _context.GetUsers().Add(new User(username));
            }
        }

        public void RemoveUser(IUser user)
        {
            _context.GetUsers().Remove(user);
        }

        public void RemoveAllUsers()
        {
            _context.GetUsers().Clear();
        }

        public IUser GetUser(string username)
        {
            foreach (IUser user in _context.GetUsers().ToList())
            {
                if (user.Username == username)
                {
                    return user;
                }
            }
            return null;
        }

        public List<IUser> GetAllUsers()
        {
            if (GetUsersNumber() != 0)
            {
                return new List<IUser>(_context.GetUsers());
            }
            return null;
        }

        public int GetUsersNumber()
        {
            return _context.GetUsers().Count();
        }
    }
}
