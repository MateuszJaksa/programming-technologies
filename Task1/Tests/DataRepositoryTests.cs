using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class DataRepositoryTests
    {
        private DataRepository repository;

        [TestMethod]
        public void AddAndRemoveCatalogTest()
        {
            repository = new Data.DataRepository();
            repository.AddCatalog("Frank Herbert");
            repository.AddCatalog("Szczepan Twardoch");
            Assert.AreEqual(repository.GetCatalogsNumber(), 2);
            repository.RemoveCatalog(repository.GetCatalog("Frank Herbert"));
            repository.RemoveCatalog(repository.GetCatalog("Szczepan Twardoch"));
            Assert.AreEqual(repository.GetCatalogsNumber(), 0);
        }

        [TestMethod]
        public void GetExistingAndNonExistingCatalogTest()
        {
            repository = new Data.DataRepository();
            repository.AddCatalog("Frank Herbert");
            repository.AddCatalog("Szczepan Twardoch");
            Catalog existCatalog = repository.GetCatalog("Frank Herbert");
            Catalog nonExistCatalog = repository.GetCatalog("Michel Houellebecq");
            Assert.IsNotNull(existCatalog);
            Assert.AreEqual(existCatalog.Author, "Frank Herbert");
            Assert.IsNull(nonExistCatalog);
        }

        [TestMethod]
        public void AddAlreadyExistingCatalogTest()
        {
            repository = new Data.DataRepository();
            repository.AddCatalog("Frank Herbert");
            repository.AddCatalog("Szczepan Twardoch");
            Assert.AreEqual(repository.GetCatalogsNumber(), 2);
            repository.AddCatalog("Frank Herbert");
            Assert.AreEqual(repository.GetCatalogsNumber(), 2);
        }

        [TestMethod]
        public void RemoveNonExistingCatalogTest()
        {
            repository = new Data.DataRepository();
            repository.AddCatalog("Frank Herbert");
            repository.AddCatalog("Szczepan Twardoch");
            Assert.AreEqual(repository.GetCatalogsNumber(), 2);
            repository.RemoveCatalog(repository.GetCatalog("Michel Houellebecq"));
            Assert.AreEqual(repository.GetCatalogsNumber(), 2);
        }

        [TestMethod]
        public void RemoveAllCatalogsTest()
        {
            repository = new Data.DataRepository();
            repository.AddCatalog("Frank Herbert");
            repository.AddCatalog("Szczepan Twardoch");
            repository.AddCatalog("Michel Houellebecq");
            Assert.AreEqual(repository.GetCatalogsNumber(), 3);
            repository.RemoveAllCatalogs();
            Assert.AreEqual(repository.GetCatalogsNumber(), 0);
        }

        [TestMethod]
        public void GetAllCatalogsTest()
        {
            repository = new Data.DataRepository();
            repository.AddCatalog("Frank Herbert");
            repository.AddCatalog("Szczepan Twardoch");
            repository.AddCatalog("Michel Houellebecq");
            List<Catalog> catalogs = repository.GetAllCatalogs();
            Assert.AreEqual(repository.GetCatalogsNumber(), 3);
            Assert.AreEqual(catalogs.Count, 3);
            Assert.AreEqual(catalogs[0].Author, "Frank Herbert");
            Assert.AreEqual(catalogs[1].Author, "Szczepan Twardoch");
            Assert.AreEqual(catalogs[2].Author, "Michel Houellebecq");
        }

        [TestMethod]
        public void AddAndRemoveEventTest()
        {
            repository = new Data.DataRepository();
            Catalog catalog1 = new Catalog("Frank Herbert");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
            State state2 = new State(catalog2, "Krol");
            User user2 = new User("Michael Johnson");
            repository.AddEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            Assert.AreEqual(repository.GetEventsNumber(), 2);
            repository.RemoveEvent(repository.GetEvent(new DateTime(2020, 11, 08, 12, 0, 0), "John Smith"));
            repository.RemoveEvent(repository.GetEvent(new DateTime(2020, 11, 08, 12, 1, 0), "Michael Johnson"));
            Assert.AreEqual(repository.GetEventsNumber(), 0);
        }

        [TestMethod]
        public void GetExistingAndNonExistingEventTest()
        {
            repository = new Data.DataRepository();
            Catalog catalog1 = new Catalog("Frank Herbert");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
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
            repository = new Data.DataRepository();
            Catalog catalog1 = new Catalog("Frank Herbert");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
            State state2 = new State(catalog2, "Krol");
            User user2 = new User("Michael Johnson");
            repository.AddEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            Assert.AreEqual(repository.GetEventsNumber(), 2);
            Catalog catalog3 = new Catalog("Frank Herbert");
            State state3 = new State(catalog3, "Dune");
            User user3 = new User("John Smith");
            repository.AddEvent(state3, user3, new DateTime(2020, 11, 08, 12, 0, 0));
            Assert.AreEqual(repository.GetEventsNumber(), 2);
        }

        [TestMethod]
        public void RemoveNonExistingEventTest()
        {
            repository = new Data.DataRepository();
            Catalog catalog1 = new Catalog("Frank Herbert");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
            State state2 = new State(catalog2, "Krol");
            User user2 = new User("Michael Johnson");
            repository.AddEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            Assert.AreEqual(repository.GetEventsNumber(), 2);
            repository.RemoveEvent(repository.GetEvent(new DateTime(2021, 11, 08, 12, 0, 0), "Michel Houellebecq"));
            Assert.AreEqual(repository.GetEventsNumber(), 2);
        }

        [TestMethod]
        public void RemoveAllEventsTest()
        {
            repository = new Data.DataRepository();
            Catalog catalog1 = new Catalog("Frank Herbert");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
            State state2 = new State(catalog2, "Krol");
            User user2 = new User("Michael Johnson");
            Catalog catalog3 = new Catalog("Michel Houellebecq");
            State state3 = new State(catalog3, "Serotonin");
            User user3 = new User("James Martinez");
            repository.AddEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            repository.AddEvent(state3, user3, new DateTime(2020, 11, 08, 12, 2, 0));
            Assert.AreEqual(repository.GetEventsNumber(), 3);
            repository.RemoveAllEvents();
            Assert.AreEqual(repository.GetEventsNumber(), 0);
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            repository = new Data.DataRepository();
            Catalog catalog1 = new Catalog("Frank Herbert");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
            State state2 = new State(catalog2, "Krol");
            User user2 = new User("Michael Johnson");
            Catalog catalog3 = new Catalog("Michel Houellebecq");
            State state3 = new State(catalog3, "Serotonin");
            User user3 = new User("James Martinez");
            repository.AddEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            repository.AddEvent(state3, user3, new DateTime(2020, 11, 08, 12, 2, 0));
            List<Event> events = repository.GetAllEvents();
            Assert.AreEqual(repository.GetEventsNumber(), 3);
            Assert.AreEqual(events.Count, 3);
            Assert.AreEqual(events[0].Time, new DateTime(2020, 11, 08, 12, 0, 0));
            Assert.AreEqual(events[1].Time, new DateTime(2020, 11, 08, 12, 1, 0));
            Assert.AreEqual(events[2].Time, new DateTime(2020, 11, 08, 12, 2, 0));
        }

        [TestMethod]
        public void AddAndRemoveStateTest()
        {
            repository = new Data.DataRepository();
            Catalog catalog1 = new Catalog("Frank Herbert");
            repository.AddState(catalog1, "Dune");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
            repository.AddState(catalog2, "Krol");
            Assert.AreEqual(repository.GetStatesNumber(), 2);
            repository.RemoveState(repository.GetState("Dune"));
            repository.RemoveState(repository.GetState("Krol"));
            Assert.AreEqual(repository.GetStatesNumber(), 0);
        }

        [TestMethod]
        public void GetExistingAndNonExistingStateTest()
        {
            repository = new Data.DataRepository();
            Catalog catalog1 = new Catalog("Frank Herbert");
            repository.AddState(catalog1, "Dune");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
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
            repository = new Data.DataRepository();
            Catalog catalog1 = new Catalog("Frank Herbert");
            repository.AddState(catalog1, "Dune");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
            repository.AddState(catalog2, "Krol");
            Assert.AreEqual(repository.GetStatesNumber(), 2);
            Catalog catalog3 = new Catalog("Frank Herbert");
            repository.AddState(catalog3, "Dune");
            Assert.AreEqual(repository.GetStatesNumber(), 2);
        }

        [TestMethod]
        public void RemoveNonExistingStateTest()
        {
            repository = new Data.DataRepository();
            Catalog catalog1 = new Catalog("Frank Herbert");
            repository.AddState(catalog1, "Dune");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
            repository.AddState(catalog2, "Krol");
            Assert.AreEqual(repository.GetStatesNumber(), 2);
            repository.RemoveState(repository.GetState("Serotonin"));
            Assert.AreEqual(repository.GetStatesNumber(), 2);
        }

        [TestMethod]
        public void RemoveAllStatesTest()
        {
            repository = new Data.DataRepository();
            Catalog catalog1 = new Catalog("Frank Herbert");
            repository.AddState(catalog1, "Dune");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
            repository.AddState(catalog2, "Krol");
            Catalog catalog3 = new Catalog("Michel Houellebecq");
            repository.AddState(catalog3, "Serotonin");
            Assert.AreEqual(repository.GetStatesNumber(), 3);
            repository.RemoveAllStates();
            Assert.AreEqual(repository.GetStatesNumber(), 0);
        }

        [TestMethod]
        public void GetAllStatesTest()
        {
            repository = new Data.DataRepository();
            Catalog catalog1 = new Catalog("Frank Herbert");
            repository.AddState(catalog1, "Dune");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
            repository.AddState(catalog2, "Krol");
            Catalog catalog3 = new Catalog("Michel Houellebecq");
            repository.AddState(catalog3, "Serotonin");
            List<State> states = repository.GetAllStates();
            Assert.AreEqual(repository.GetStatesNumber(), 3);
            Assert.AreEqual(states.Count, 3);
            Assert.AreEqual(states[0].Title, "Dune");
            Assert.AreEqual(states[1].Title, "Krol");
            Assert.AreEqual(states[2].Title, "Serotonin");
        }

        [TestMethod]
        public void AddAndRemoveUserTest()
        {
            repository = new Data.DataRepository();
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            Assert.AreEqual(repository.GetUsersNumber(), 2);
            repository.RemoveUser(repository.GetUser("John Smith"));
            repository.RemoveUser(repository.GetUser("Michael Johnson"));
            Assert.AreEqual(repository.GetUsersNumber(), 0);
        }

        [TestMethod]
        public void GetExistingAndNonExistingUserTest()
        {
            repository = new Data.DataRepository();
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
            repository = new Data.DataRepository();
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            Assert.AreEqual(repository.GetUsersNumber(), 2);
            repository.AddUser("John Smith");
            Assert.AreEqual(repository.GetUsersNumber(), 2);
        }

        [TestMethod]
        public void RemoveNonExistingUserTest()
        {
            repository = new Data.DataRepository();
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            Assert.AreEqual(repository.GetUsersNumber(), 2);
            repository.RemoveUser(repository.GetUser("James Martinez"));
            Assert.AreEqual(repository.GetUsersNumber(), 2);
        }

        [TestMethod]
        public void RemoveAllUsersTest()
        {
            repository = new Data.DataRepository();
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            repository.AddUser("James Martinez");
            Assert.AreEqual(repository.GetUsersNumber(), 3);
            repository.RemoveAllUsers();
            Assert.AreEqual(repository.GetUsersNumber(), 0);
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            repository = new Data.DataRepository();
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            repository.AddUser("James Martinez");
            List<User> users = repository.GetAllUsers();
            Assert.AreEqual(repository.GetUsersNumber(), 3);
            Assert.AreEqual(users.Count, 3);
            Assert.AreEqual(users[0].Username, "John Smith");
            Assert.AreEqual(users[1].Username, "Michael Johnson");
            Assert.AreEqual(users[2].Username, "James Martinez");
        }
    }
}
