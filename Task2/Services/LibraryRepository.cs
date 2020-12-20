using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class LibraryRepository
    {
        private readonly LinqToSqlDataContext dataContext = new LinqToSqlDataContext();

        public LibraryRepository()
        {
            
        }

        public void AddCatalog(string title, string author)
        {   if (GetCatalog(title, author) == null)
            {
                Catalogs newCatalog = new Catalogs
                {
                    Title = title,
                    Author = author
                };
                dataContext.Catalogs.InsertOnSubmit(newCatalog);
                dataContext.SubmitChanges();
            }
        }

        public void RemoveCatalog(Catalogs catalog)
        {
            if (catalog != null)
            {
                dataContext.Catalogs.DeleteOnSubmit(catalog);
                dataContext.SubmitChanges();
            }
        }

        public void RemoveAllCatalogs()
        {
            dataContext.ExecuteCommand(@"DELETE FROM Catalogs;");
        }

        public Catalogs GetCatalog(string title, string author)
        {
            foreach (Catalogs catalog in dataContext.Catalogs.ToList())
            {
                if (catalog.Title == title && catalog.Author == author)
                {
                    return catalog;
                }
            }
            return null;
        }
        public List<Catalogs> GetAllCatalogs()
        {
            if (GetCatalogsNumber() != 0)
            {
                return new List<Catalogs>(dataContext.Catalogs);
            }
            return null;
        }

        public int GetCatalogsNumber()
        {
            return dataContext.Catalogs.Count();
        }

        public void AddBorrowEvent(States state, Users user, DateTime time)
        {
            LibraryEvents borrowEvent = new LibraryEvents
            {
                Time = time,
                StateId = state.ID,
                UserId = user.ID,
                isBorrowingEvent = true
            };
            if ((bool)!state.IsBorrowed)
            {
                state.IsBorrowed = true;
            }
            else
            {
                throw new Exception("A borrowed book can not be borrowed");
            }
            dataContext.LibraryEvents.InsertOnSubmit(borrowEvent);
            dataContext.SubmitChanges();
        }

        public void AddReturnEvent(States state, Users user, DateTime time)
        {
            LibraryEvents returnEvent = new LibraryEvents
            {
                Time = time,
                StateId = state.ID,
                UserId = user.ID,
                isBorrowingEvent = false
            };
            if ((bool)state.IsBorrowed)
            {
                state.IsBorrowed = false;
            }
            else
            {
                throw new Exception("A not borrowed book can not be returned");
            }
            dataContext.LibraryEvents.InsertOnSubmit(returnEvent);
            dataContext.SubmitChanges();
        }

        public void RemoveEvent(LibraryEvents removedEvent)
        {
            if (removedEvent != null)
            {
                dataContext.LibraryEvents.DeleteOnSubmit(removedEvent);
                dataContext.SubmitChanges();
            }
        }

        public void RemoveAllEvents()
        {
            dataContext.ExecuteCommand(@"DELETE FROM LibraryEvents;");
        }

        public LibraryEvents GetEvent(DateTime time, string eventUsername)
        {
            foreach (LibraryEvents currentEvent in dataContext.LibraryEvents.ToList())
            {
                if (currentEvent.Time == time && currentEvent.Users.Name ==  eventUsername)
                {
                    return currentEvent;
                }
            }
            return null;
        }

        public List<LibraryEvents> GetAllEvents()
        {
            if (GetEventsNumber() != 0)
            {
                return new List<LibraryEvents>(dataContext.LibraryEvents);
            }
            return null;
        }

        public int GetEventsNumber()
        {
            return dataContext.LibraryEvents.Count();
        }

        public int AddState(Catalogs catalog)
        {
            States newState = new States
            {
                IsBorrowed = false,
                CatalogId = catalog.ID
            };
            dataContext.States.InsertOnSubmit(newState);
            dataContext.SubmitChanges();
            return newState.ID;
        }

        public void RemoveState(States state)
        {
            if (state != null)
            {
                dataContext.States.DeleteOnSubmit(state);
                dataContext.SubmitChanges();
            }
        }

        public void RemoveAllStates()
        {
            dataContext.ExecuteCommand(@"DELETE FROM States;");
        }

        public States GetState(int id)
        {
            foreach (States state in dataContext.States.ToList())
            {
                if (state.ID == id)
                {
                    return state;
                }
            }
            return null;
        }

        public List<States> GetAllStates()
        {
            if (GetStatesNumber() != 0)
            {
                return new List<States>(dataContext.States);
            }
            return null;
        }

        public int GetStatesNumber()
        {
            return dataContext.States.Count();
        }

        public void AddUser(string username)
        {
            if (GetUser(username) == null)
            {
                Users newUser = new Users
                {
                    Name = username
                };
                dataContext.Users.InsertOnSubmit(newUser);
                dataContext.SubmitChanges();
            }
        }

        public void RemoveUser(Users user)
        {
            if (user != null)
            {
                dataContext.Users.DeleteOnSubmit(user);
                dataContext.SubmitChanges();
            }
        }

        public void RemoveAllUsers()
        {
            dataContext.ExecuteCommand(@"DELETE FROM Users;");
        }

        public Users GetUser(string username)
        {
            foreach (Users user in dataContext.Users.ToList())
            {
                if (user.Name == username)
                {
                    return user;
                }
            }
            return null;
        }

        public List<Users> GetAllUsers()
        {
            if (GetUsersNumber() != 0)
            {
                return new List<Users>(dataContext.Users);
            }
            return null;
        }

        public int GetUsersNumber()
        {
            return dataContext.Users.Count();
        }
    }
}
