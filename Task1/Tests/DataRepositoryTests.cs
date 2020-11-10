using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class DataRepositoryTests
    {
        private DataContext context;
        private DataRepository repository;

        [TestMethod]
        public void AddAndRemoveCatalogTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            repository.AddCatalog("Frank Herbert", "Science Fiction");
            repository.AddCatalog("Szczepan Twardoch", "Novel");
            Assert.AreEqual(context.catalogs.Count, 2);
            repository.RemoveCatalog(repository.GetCatalog("Frank Herbert", "Science Fiction"));
            repository.RemoveCatalog(repository.GetCatalog("Szczepan Twardoch", "Novel"));
            Assert.AreEqual(context.catalogs.Count, 0);
        }

        [TestMethod]
        public void GetExistingAndNonExistingCatalogTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            repository.AddCatalog("Frank Herbert", "Science Fiction");
            repository.AddCatalog("Szczepan Twardoch", "Novel");
            Catalog existCatalog = repository.GetCatalog("Frank Herbert", "Science Fiction");
            Catalog nonExistCatalog = repository.GetCatalog("Michel Houellebecq", "Novel");
            Assert.IsNotNull(existCatalog);
            Assert.AreEqual(existCatalog.Author, "Frank Herbert");
            Assert.AreEqual(existCatalog.Genre, "Science Fiction");
            Assert.IsNull(nonExistCatalog);
        }

        [TestMethod]
        public void AddAlreadyExistingCatalogTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            repository.AddCatalog("Frank Herbert", "Science Fiction");
            repository.AddCatalog("Szczepan Twardoch", "Novel");
            Assert.AreEqual(context.catalogs.Count, 2);
            repository.AddCatalog("Frank Herbert", "Science Fiction");
            Assert.AreEqual(context.catalogs.Count, 2);
        }

        [TestMethod]
        public void RemoveNonExistingCatalogTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            repository.AddCatalog("Frank Herbert", "Science Fiction");
            repository.AddCatalog("Szczepan Twardoch", "Novel");
            Assert.AreEqual(context.catalogs.Count, 2);
            repository.RemoveCatalog(repository.GetCatalog("Michel Houellebecq", "Novel"));
            Assert.AreEqual(context.catalogs.Count, 2);
        }

        [TestMethod]
        public void RemoveAllCatalogsTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            repository.AddCatalog("Frank Herbert", "Science Fiction");
            repository.AddCatalog("Szczepan Twardoch", "Novel");
            repository.AddCatalog("Michel Houellebecq", "Novel");
            Assert.AreEqual(context.catalogs.Count, 3);
            repository.RemoveAllCatalogs();
            Assert.AreEqual(context.catalogs.Count, 0);
        }

        [TestMethod]
        public void GetAllCatalogsTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            repository.AddCatalog("Frank Herbert", "Science Fiction");
            repository.AddCatalog("Szczepan Twardoch", "Novel");
            repository.AddCatalog("Michel Houellebecq", "Novel");
            List<Catalog> catalogs = repository.GetAllCatalogs();
            Assert.AreEqual(context.catalogs.Count, 3);
            Assert.AreEqual(catalogs.Count, 3);
            Assert.AreEqual(catalogs[0].Author, "Frank Herbert");
            Assert.AreEqual(catalogs[1].Author, "Szczepan Twardoch");
            Assert.AreEqual(catalogs[2].Author, "Michel Houellebecq");
            Assert.AreEqual(catalogs[0].Genre, "Science Fiction");
            Assert.AreEqual(catalogs[1].Genre, "Novel");
            Assert.AreEqual(catalogs[2].Genre, "Novel");
        }

        [TestMethod]
        public void AddAndRemoveEventTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            Catalog catalog1 = new Catalog("Frank Herbert", "Science Fiction");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch", "Novel");
            State state2 = new State(catalog2, "Krol");
            User user2 = new User("Michael Johnson");
            repository.AddEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            Assert.AreEqual(context.events.Count, 2);
            repository.RemoveEvent(repository.GetEvent(new DateTime(2020, 11, 08, 12, 0, 0), "John Smith"));
            repository.RemoveEvent(repository.GetEvent(new DateTime(2020, 11, 08, 12, 1, 0), "Michael Johnson"));
            Assert.AreEqual(context.events.Count, 0);
        }

        [TestMethod]
        public void GetExistingAndNonExistingEventTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            Catalog catalog1 = new Catalog("Frank Herbert", "Science Fiction");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch", "Novel");
            State state2 = new State(catalog2, "Krol");
            User user2 = new User("Michael Johnson");
            repository.AddEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            Event existEvent = repository.GetEvent(new DateTime(2020, 11, 08, 12, 0, 0), "John Smith");
            Event nonExistEvent = repository.GetEvent(new DateTime(2021, 11, 08, 12, 0, 0), "Michel Houellebecq");
            Assert.IsNotNull(existEvent);
            Assert.AreEqual(existEvent.Time, new DateTime(2020, 11, 08, 12, 0, 0));
            Assert.IsNull(nonExistEvent);
        }

        [TestMethod]
        public void AddAlreadyExistingEventTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            Catalog catalog1 = new Catalog("Frank Herbert", "Science Fiction");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch", "Novel");
            State state2 = new State(catalog2, "Krol");
            User user2 = new User("Michael Johnson");
            repository.AddEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            Assert.AreEqual(context.events.Count, 2);
            Catalog catalog3 = new Catalog("Frank Herbert", "Science Fiction");
            State state3 = new State(catalog3, "Dune");
            User user3 = new User("John Smith");
            repository.AddEvent(state3, user3, new DateTime(2020, 11, 08, 12, 0, 0));
            Assert.AreEqual(context.events.Count, 2);
        }

        [TestMethod]
        public void RemoveNonExistingEventTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            Catalog catalog1 = new Catalog("Frank Herbert", "Science Fiction");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch", "Novel");
            State state2 = new State(catalog2, "Krol");
            User user2 = new User("Michael Johnson");
            repository.AddEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            Assert.AreEqual(context.events.Count, 2);
            repository.RemoveEvent(repository.GetEvent(new DateTime(2021, 11, 08, 12, 0, 0), "Michel Houellebecq"));
            Assert.AreEqual(context.events.Count, 2);
        }

        [TestMethod]
        public void RemoveAllEventsTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            Catalog catalog1 = new Catalog("Frank Herbert", "Science Fiction");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch", "Novel");
            State state2 = new State(catalog2, "Krol");
            User user2 = new User("Michael Johnson");
            Catalog catalog3 = new Catalog("Michel Houellebecq", "Novel");
            State state3 = new State(catalog3, "Serotonin");
            User user3 = new User("James Martinez");
            repository.AddEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            repository.AddEvent(state3, user3, new DateTime(2020, 11, 08, 12, 2, 0));
            Assert.AreEqual(context.events.Count, 3);
            repository.RemoveAllEvents();
            Assert.AreEqual(context.events.Count, 0);
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            Catalog catalog1 = new Catalog("Frank Herbert", "Science Fiction");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch", "Novel");
            State state2 = new State(catalog2, "Krol");
            User user2 = new User("Michael Johnson");
            Catalog catalog3 = new Catalog("Michel Houellebecq", "Novel");
            State state3 = new State(catalog3, "Serotonin");
            User user3 = new User("James Martinez");
            repository.AddEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            repository.AddEvent(state3, user3, new DateTime(2020, 11, 08, 12, 2, 0));
            List<Event> events = repository.GetAllEvents();
            Assert.AreEqual(context.events.Count, 3);
            Assert.AreEqual(events.Count, 3);
            Assert.AreEqual(events[0].Time, new DateTime(2020, 11, 08, 12, 0, 0));
            Assert.AreEqual(events[1].Time, new DateTime(2020, 11, 08, 12, 1, 0));
            Assert.AreEqual(events[2].Time, new DateTime(2020, 11, 08, 12, 2, 0));
        }

        [TestMethod]
        public void AddAndRemoveStateTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            Catalog catalog1 = new Catalog("Frank Herbert", "Science Fiction");
            repository.AddState(catalog1, "Dune");
            Catalog catalog2 = new Catalog("Szczepan Twardoch", "Novel");
            repository.AddState(catalog2, "Krol");
            Assert.AreEqual(context.states.Count, 2);
            repository.RemoveState(repository.GetState("Dune"));
            repository.RemoveState(repository.GetState("Krol"));
            Assert.AreEqual(context.states.Count, 0);
        }

        [TestMethod]
        public void GetExistingAndNonExistingStateTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            Catalog catalog1 = new Catalog("Frank Herbert", "Science Fiction");
            repository.AddState(catalog1, "Dune");
            Catalog catalog2 = new Catalog("Szczepan Twardoch", "Novel");
            repository.AddState(catalog2, "Krol");
            State existState = repository.GetState("Dune");
            State nonExistState = repository.GetState("Serotonin");
            Assert.IsNotNull(existState);
            Assert.AreEqual(existState.Title, "Dune");
            Assert.IsNull(nonExistState);
        }

        [TestMethod]
        public void AddAlreadyExistingStateTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            Catalog catalog1 = new Catalog("Frank Herbert", "Science Fiction");
            repository.AddState(catalog1, "Dune");
            Catalog catalog2 = new Catalog("Szczepan Twardoch", "Novel");
            repository.AddState(catalog2, "Krol");
            Assert.AreEqual(context.states.Count, 2);
            Catalog catalog3 = new Catalog("Frank Herbert", "Science Fiction");
            repository.AddState(catalog3, "Dune");
            Assert.AreEqual(context.states.Count, 2);
        }

        [TestMethod]
        public void RemoveNonExistingStateTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            Catalog catalog1 = new Catalog("Frank Herbert", "Science Fiction");
            repository.AddState(catalog1, "Dune");
            Catalog catalog2 = new Catalog("Szczepan Twardoch", "Novel");
            repository.AddState(catalog2, "Krol");
            Assert.AreEqual(context.states.Count, 2);
            repository.RemoveState(repository.GetState("Serotonin"));
            Assert.AreEqual(context.states.Count, 2);
        }

        [TestMethod]
        public void RemoveAllStatesTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            Catalog catalog1 = new Catalog("Frank Herbert", "Science Fiction");
            repository.AddState(catalog1, "Dune");
            Catalog catalog2 = new Catalog("Szczepan Twardoch", "Novel");
            repository.AddState(catalog2, "Krol");
            Catalog catalog3 = new Catalog("Michel Houellebecq", "Novel");
            repository.AddState(catalog3, "Serotonin");
            Assert.AreEqual(context.states.Count, 3);
            repository.RemoveAllStates();
            Assert.AreEqual(context.states.Count, 0);
        }

        [TestMethod]
        public void GetAllStatesTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            Catalog catalog1 = new Catalog("Frank Herbert", "Science Fiction");
            repository.AddState(catalog1, "Dune");
            Catalog catalog2 = new Catalog("Szczepan Twardoch", "Novel");
            repository.AddState(catalog2, "Krol");
            Catalog catalog3 = new Catalog("Michel Houellebecq", "Novel");
            repository.AddState(catalog3, "Serotonin");
            List<State> states = repository.GetAllStates();
            Assert.AreEqual(context.states.Count, 3);
            Assert.AreEqual(states.Count, 3);
            Assert.AreEqual(states[0].Title, "Dune");
            Assert.AreEqual(states[1].Title, "Krol");
            Assert.AreEqual(states[2].Title, "Serotonin");
        }

        [TestMethod]
        public void AddAndRemoveUserTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            Assert.AreEqual(context.users.Count, 2);
            repository.RemoveUser(repository.GetUser("John Smith"));
            repository.RemoveUser(repository.GetUser("Michael Johnson"));
            Assert.AreEqual(context.users.Count, 0);
        }

        [TestMethod]
        public void GetExistingAndNonExistingUserTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            User existUser = repository.GetUser("John Smith");
            User nonExistUser = repository.GetUser("James Martinez");
            Assert.IsNotNull(existUser);
            Assert.AreEqual(existUser.Username, "John Smith");
            Assert.IsNull(nonExistUser);
        }

        [TestMethod]
        public void AddAlreadyExistingUserTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            Assert.AreEqual(context.users.Count, 2);
            repository.AddUser("John Smith");
            Assert.AreEqual(context.users.Count, 2);
        }

        [TestMethod]
        public void RemoveNonExistingUserTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            Assert.AreEqual(context.users.Count, 2);
            repository.RemoveUser(repository.GetUser("James Martinez"));
            Assert.AreEqual(context.users.Count, 2);
        }

        [TestMethod]
        public void RemoveAllUsersTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            repository.AddUser("James Martinez");
            Assert.AreEqual(context.users.Count, 3);
            repository.RemoveAllUsers();
            Assert.AreEqual(context.users.Count, 0);
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            repository.AddUser("James Martinez");
            List<User> users = repository.GetAllUsers();
            Assert.AreEqual(context.users.Count, 3);
            Assert.AreEqual(users.Count, 3);
            Assert.AreEqual(users[0].Username, "John Smith");
            Assert.AreEqual(users[1].Username, "Michael Johnson");
            Assert.AreEqual(users[2].Username, "James Martinez");
        }
    }
}
