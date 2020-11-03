﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataRepository
    {
        private DataContext _context;

        DataRepository(DataContext context)
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
            foreach (Catalog catalog in _context.catalogs)
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

        public void AddEvent(DateTime time, State state, User user)
        {
            if (GetEvent(time) == null)
            {
                _context.events.Add(new Event(state, user));
            }
        }

        public void RemoveEvent(DateTime time)
        {
            foreach (Event currentEvent in _context.events)
            {
                if (currentEvent.Time == time)
                {
                    _context.events.Remove(currentEvent);
                }
            }
        }

        public void RemoveAllEvents()
        {
            _context.events.Clear();
        }

        public Event GetEvent(DateTime time)
        {
            foreach (Event currentEvent in _context.events)
            {
                if (currentEvent.Time == time)
                {
                    return currentEvent;
                }
            }
            return null;
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
            foreach (State state in _context.states)
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

        public void AddUser(string userName)
        {
            if (GetUser(userName) == null)
            {
                _context.users.Add(new User(userName));
            }
        }

        public void RemoveUser(string userName)
        {
            foreach (User user in _context.users)
            {
                if (user.UserName == userName)
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
                if (user.UserName == userName)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
