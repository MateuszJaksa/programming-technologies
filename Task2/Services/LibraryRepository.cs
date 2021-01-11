using System;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Services
{
    public class LibraryRepository
    {

        public LibraryRepository()
        {

        }

        public int AddCatalog(string title, string author)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                Catalogs newCatalog = new Catalogs
                {
                    Title = title,
                    Author = author
                };
                dataContext.Catalogs.InsertOnSubmit(newCatalog);
                dataContext.SubmitChanges();
                return newCatalog.ID;
            }
        }

        public void UpdateCatalog(int id, string title, string author)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                Catalogs updatedCatalog = dataContext.Catalogs.FirstOrDefault(catalog => catalog.ID == id);
                updatedCatalog.Title = title;
                updatedCatalog.Author = author;
                dataContext.SubmitChanges();
            }
        }

        public void RemoveCatalog(int id)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                bool canBeRemoved = true;
                foreach (States states in dataContext.States.ToList())
                {
                    if (states.CatalogId == id) { canBeRemoved = false; }
                }
                if (canBeRemoved)
                {
                    Catalogs removedCatalog = dataContext.Catalogs.FirstOrDefault(catalog => catalog.ID == id);
                    dataContext.Catalogs.DeleteOnSubmit(removedCatalog);
                    dataContext.SubmitChanges();
                }
            }
        }

        public void RemoveAllCatalogs()
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                dataContext.ExecuteCommand(@"DELETE FROM Catalogs;");
            }
        }

        public string GetCatalogTitle(int id)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                return dataContext.Catalogs.FirstOrDefault(catalog => catalog.ID == id).Title;
            }
        }

        public string GetCatalogAuthor(int id)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                return dataContext.Catalogs.FirstOrDefault(catalog => catalog.ID == id).Author;
            }
        }

        public List<int> GetAllCatalogIds()
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                List<int> returnedList = new List<int>();
                foreach (Catalogs catalogs in dataContext.Catalogs.ToList())
                {
                    returnedList.Add(catalogs.ID);
                }
                return returnedList;
            }
        }

        public int AddState(int catalogId, bool isBorrowed)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                States newState = new States
                {
                    IsBorrowed = isBorrowed,
                    CatalogId = catalogId
                };
                dataContext.States.InsertOnSubmit(newState);
                dataContext.SubmitChanges();
                return newState.ID;
            }
        }

        public void UpdateState(int id, int catalogId, bool isBorrowed)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                States updatedState = dataContext.States.FirstOrDefault(state => state.ID == id);
                updatedState.CatalogId = catalogId;
                updatedState.IsBorrowed = isBorrowed;
                dataContext.SubmitChanges();
            }
        }

        public void RemoveState(int id)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                bool canBeRemoved = true;
                foreach (LibraryEvents events in dataContext.LibraryEvents.ToList())
                {
                    if (events.StateId == id) { canBeRemoved = false; }
                }
                if (canBeRemoved)
                {
                    States removedState = dataContext.States.FirstOrDefault(state => state.ID == id);
                    dataContext.States.DeleteOnSubmit(removedState);
                    dataContext.SubmitChanges();
                }
            }
        }

        public void RemoveAllStates()
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                dataContext.ExecuteCommand(@"DELETE FROM States;");
            }
        }

        public bool GetStateIsBorrowed(int id)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                return (bool)dataContext.States.FirstOrDefault(state => state.ID == id).IsBorrowed;
            }
        }

        public int GetStateCatalogId(int id)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                return (int)dataContext.States.FirstOrDefault(state => state.ID == id).CatalogId;
            }
        }

        public List<int> GetAllStateIds()
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                List<int> returnedList = new List<int>();
                foreach (States state in dataContext.States.ToList())
                {
                    returnedList.Add(state.ID);
                }
                return returnedList;
            }
        }

        public int AddEvent(DateTime time, int stateId, int userId, bool isBorrowingEvent)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                LibraryEvents newEvent = new LibraryEvents
                {
                    Time = time,
                    StateId = stateId,
                    UserId = userId,
                    isBorrowingEvent = isBorrowingEvent
                };
                dataContext.LibraryEvents.InsertOnSubmit(newEvent);
                dataContext.SubmitChanges();
                return newEvent.ID;
            }
        }

        public void UpdateEvent(int id, DateTime time, int stateId, int userId, bool isBorrowingEvent)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                LibraryEvents updatedEvent = dataContext.LibraryEvents.FirstOrDefault(ev => ev.ID == id);
                updatedEvent.Time = time;
                updatedEvent.StateId = stateId;
                updatedEvent.UserId = userId;
                updatedEvent.isBorrowingEvent = isBorrowingEvent;
                dataContext.SubmitChanges();
            }
        }

        public void RemoveEvent(int id)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                LibraryEvents removedEvent = dataContext.LibraryEvents.FirstOrDefault(ev => ev.ID == id);
                dataContext.LibraryEvents.DeleteOnSubmit(removedEvent);
                dataContext.SubmitChanges();
            }
        }

        public void RemoveAllEvents()
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                dataContext.ExecuteCommand(@"DELETE FROM LibraryEvents;");
            }
        }

        public DateTime GetEventTime(int id)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                return (DateTime)dataContext.LibraryEvents.FirstOrDefault(ev => ev.ID == id).Time;
            }
        }

        public int GetEventStateId(int id)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                return (int)dataContext.LibraryEvents.FirstOrDefault(ev => ev.ID == id).StateId;
            }
        }

        public int GetEventUserId(int id)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                return (int)dataContext.LibraryEvents.FirstOrDefault(ev => ev.ID == id).UserId;
            }
        }

        public bool GetEventIsBorrowingEvent(int id)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                return (bool)dataContext.LibraryEvents.FirstOrDefault(ev => ev.ID == id).isBorrowingEvent;
            }
        }

        public List<int> GetAllEventIds()
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                List<int> returnedList = new List<int>();
                foreach (LibraryEvents ev in dataContext.LibraryEvents.ToList())
                {
                    returnedList.Add(ev.ID);
                }
                return returnedList;
            }
        }

        public int AddUser(string name)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                Users newUser = new Users
                {
                    Name = name
                };
                dataContext.Users.InsertOnSubmit(newUser);
                dataContext.SubmitChanges();
                return newUser.ID;
            }
        }

        public void UpdateUser(int id, string name)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                Users updatedUser = dataContext.Users.FirstOrDefault(user => user.ID == id);
                updatedUser.Name = name;
                dataContext.SubmitChanges();
            }
        }

        public void RemoveUser(int id)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                bool canBeRemoved = true;
                foreach (LibraryEvents events in dataContext.LibraryEvents.ToList())
                {
                    if (events.UserId == id) { canBeRemoved = false; }
                }
                if (canBeRemoved)
                {
                    Users removedUser = dataContext.Users.FirstOrDefault(user => user.ID == id);
                    dataContext.Users.DeleteOnSubmit(removedUser);
                    dataContext.SubmitChanges();
                }
            }
        }

        public void RemoveAllUsers()
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                dataContext.ExecuteCommand(@"DELETE FROM Users;");
            }
        }

        public string GetUserName(int id)
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                return dataContext.Users.FirstOrDefault(user => user.ID == id).Name;
            }
        }

        public List<int> GetAllUserIds()
        {
            using (LinqToSqlDataContext dataContext = new LinqToSqlDataContext())
            {
                List<int> returnedList = new List<int>();
                foreach (Users user in dataContext.Users.ToList())
                {
                    returnedList.Add(user.ID);
                }
                return returnedList;
            }
        }
    }
}
