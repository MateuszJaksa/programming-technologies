using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class DataRepository
    {
        private readonly LinqToSqlDataContext dataContext = new LinqToSqlDataContext();

        public DataRepository()
        {
            
        }

        public void AddCatalog(string title, string author)
        {   if (GetCatalog(title, author) == null)
            {
                Catalog newCatalog = new Catalog
                {
                    Title = title,
                    Author = author
                };
                dataContext.Catalog.InsertOnSubmit(newCatalog);
                dataContext.SubmitChanges();
            }
        }

        public void RemoveCatalog(Catalog catalog)
        {
            if (catalog != null)
            {
                dataContext.Catalog.DeleteOnSubmit(catalog);
                dataContext.SubmitChanges();
            }
        }

        public void RemoveAllCatalogs()
        {
            dataContext.ExecuteCommand(@"DELETE FROM Catalog;");
        }

        public Catalog GetCatalog(string title, string author)
        {
            foreach (Catalog catalog in dataContext.Catalog.ToList())
            {
                if (catalog.Title == title && catalog.Author == author)
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
                return new List<Catalog>(dataContext.Catalog);
            }
            return null;
        }

        public int GetCatalogsNumber()
        {
            return dataContext.Catalog.Count();
        }

        public void AddBorrowEvent(State state, Person user, DateTime time)
        {
            LibraryEvent borrowEvent = new LibraryEvent
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
            dataContext.LibraryEvent.InsertOnSubmit(borrowEvent);
            dataContext.SubmitChanges();
        }

        public void AddReturnEvent(State state, Person user, DateTime time)
        {
            LibraryEvent returnEvent = new LibraryEvent
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
            dataContext.LibraryEvent.InsertOnSubmit(returnEvent);
            dataContext.SubmitChanges();
        }

        public void RemoveEvent(LibraryEvent removedEvent)
        {
            if (removedEvent != null)
            {
                dataContext.LibraryEvent.DeleteOnSubmit(removedEvent);
                dataContext.SubmitChanges();
            }
        }

        public void RemoveAllEvents()
        {
            dataContext.ExecuteCommand(@"DELETE FROM LibraryEvent;");
        }

        public LibraryEvent GetEvent(DateTime time, string eventUsername)
        {
            foreach (LibraryEvent currentEvent in dataContext.LibraryEvent.ToList())
            {
                if (currentEvent.Time == time && currentEvent.Person.Name ==  eventUsername)
                {
                    return currentEvent;
                }
            }
            return null;
        }

        public List<LibraryEvent> GetAllEvents()
        {
            if (GetEventsNumber() != 0)
            {
                return new List<LibraryEvent>(dataContext.LibraryEvent);
            }
            return null;
        }

        public int GetEventsNumber()
        {
            return dataContext.LibraryEvent.Count();
        }

        public int AddState(Catalog catalog)
        {
            State newState = new State
            {
                IsBorrowed = false,
                CatalogId = catalog.ID
            };
            dataContext.State.InsertOnSubmit(newState);
            dataContext.SubmitChanges();
            return newState.ID;
        }

        public void RemoveState(State state)
        {
            if (state != null)
            {
                dataContext.State.DeleteOnSubmit(state);
                dataContext.SubmitChanges();
            }
        }

        public void RemoveAllStates()
        {
            dataContext.ExecuteCommand(@"DELETE FROM State;");
        }

        public State GetState(int id)
        {
            foreach (State state in dataContext.State.ToList())
            {
                if (state.ID == id)
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
                return new List<State>(dataContext.State);
            }
            return null;
        }

        public int GetStatesNumber()
        {
            return dataContext.State.Count();
        }

        public void AddUser(string username)
        {
            if (GetUser(username) == null)
            {
                Person newUser = new Person
                {
                    Name = username
                };
                dataContext.Person.InsertOnSubmit(newUser);
                dataContext.SubmitChanges();
            }
        }

        public void RemoveUser(Person user)
        {
            if (user != null)
            {
                dataContext.Person.DeleteOnSubmit(user);
                dataContext.SubmitChanges();
            }
        }

        public void RemoveAllUsers()
        {
            dataContext.ExecuteCommand(@"DELETE FROM Person;");
        }

        public Person GetUser(string username)
        {
            foreach (Person user in dataContext.Person.ToList())
            {
                if (user.Name == username)
                {
                    return user;
                }
            }
            return null;
        }

        public List<Person> GetAllUsers()
        {
            if (GetUsersNumber() != 0)
            {
                return new List<Person>(dataContext.Person);
            }
            return null;
        }

        public int GetUsersNumber()
        {
            return dataContext.Person.Count();
        }
    }
}
