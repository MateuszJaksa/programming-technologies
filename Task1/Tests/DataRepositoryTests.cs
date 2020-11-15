using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class DataRepositoryTests
    {
        private IDataRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new DataRepository();
        }

        [TestMethod]
        public void AddAndRemoveCatalogTest()
        {
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
            repository.AddCatalog("Frank Herbert");
            repository.AddCatalog("Szczepan Twardoch");
            Assert.AreEqual(repository.GetCatalogsNumber(), 2);
            repository.AddCatalog("Frank Herbert");
            Assert.AreEqual(repository.GetCatalogsNumber(), 2);
        }

        [TestMethod]
        public void RemoveNonExistingCatalogTest()
        {
            repository.AddCatalog("Frank Herbert");
            repository.AddCatalog("Szczepan Twardoch");
            Assert.AreEqual(repository.GetCatalogsNumber(), 2);
            repository.RemoveCatalog(repository.GetCatalog("Michel Houellebecq"));
            Assert.AreEqual(repository.GetCatalogsNumber(), 2);
        }

        [TestMethod]
        public void RemoveAllCatalogsTest()
        {
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
            repository.AddCatalog("Frank Herbert");
            repository.AddCatalog("Szczepan Twardoch");
            repository.AddCatalog("Michel Houellebecq");
            List<Catalog> catalogs = repository.GetAllCatalogs();
            Assert.AreEqual(repository.GetCatalogsNumber(), 3);
            Assert.AreEqual(catalogs.Count, 3);
            Assert.IsTrue(catalogs.Exists(n => n.Author == "Frank Herbert"));
            Assert.IsTrue(catalogs.Exists(n => n.Author == "Szczepan Twardoch"));
            Assert.IsTrue(catalogs.Exists(n => n.Author == "Michel Houellebecq"));
            Assert.IsFalse(catalogs.Exists(n => n.Author == "Donald Trump"));
        }

        [TestMethod]
        public void AddAndRemoveEventTest()
        {
            Catalog catalog1 = new Catalog("Frank Herbert");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
            State state2 = new State(catalog2, "Krol");
            User user2 = new User("Michael Johnson");
            repository.AddBorrowEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddBorrowEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            Assert.AreEqual(repository.GetEventsNumber(), 2);
            repository.RemoveEvent(repository.GetEvent(new DateTime(2020, 11, 08, 12, 0, 0), "John Smith"));
            repository.RemoveEvent(repository.GetEvent(new DateTime(2020, 11, 08, 12, 1, 0), "Michael Johnson"));
            Assert.AreEqual(repository.GetEventsNumber(), 0);
        }

        [TestMethod]
        public void GetExistingAndNonExistingEventTest()
        {
            Catalog catalog1 = new Catalog("Frank Herbert");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
            State state2 = new State(catalog2, "Krol");
            User user2 = new User("Michael Johnson");
            repository.AddBorrowEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddBorrowEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            AbstractEvent existEvent = repository.GetEvent(new DateTime(2020, 11, 08, 12, 0, 0), "John Smith");
            AbstractEvent nonExistEvent = repository.GetEvent(new DateTime(2021, 11, 08, 12, 0, 0), "Michel Houellebecq");
            Assert.IsNotNull(existEvent);
            Assert.AreEqual(existEvent.Time, new DateTime(2020, 11, 08, 12, 0, 0));
            Assert.IsNull(nonExistEvent);
        }

        [TestMethod]
        public void AddAlreadyExistingEventTest()
        {
            Catalog catalog1 = new Catalog("Frank Herbert");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
            State state2 = new State(catalog2, "Krol");
            User user2 = new User("Michael Johnson");
            repository.AddBorrowEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddBorrowEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            Assert.AreEqual(repository.GetEventsNumber(), 2);
            Catalog catalog3 = new Catalog("Frank Herbert");
            State state3 = new State(catalog3, "Dune");
            User user3 = new User("John Smith");
            repository.AddBorrowEvent(state3, user3, new DateTime(2020, 11, 08, 12, 0, 0));
            Assert.AreEqual(repository.GetEventsNumber(), 2);
        }

        [TestMethod]
        public void RemoveNonExistingEventTest()
        {
            Catalog catalog1 = new Catalog("Frank Herbert");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
            State state2 = new State(catalog2, "Krol");
            User user2 = new User("Michael Johnson");
            repository.AddBorrowEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddBorrowEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            Assert.AreEqual(repository.GetEventsNumber(), 2);
            repository.RemoveEvent(repository.GetEvent(new DateTime(2021, 11, 08, 12, 0, 0), "Michel Houellebecq"));
            Assert.AreEqual(repository.GetEventsNumber(), 2);
        }

        [TestMethod]
        public void RemoveAllEventsTest()
        {
            Catalog catalog1 = new Catalog("Frank Herbert");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
            State state2 = new State(catalog2, "Krol");
            User user2 = new User("Michael Johnson");
            Catalog catalog3 = new Catalog("Michel Houellebecq");
            State state3 = new State(catalog3, "Serotonin");
            User user3 = new User("James Martinez");
            repository.AddBorrowEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddBorrowEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            repository.AddBorrowEvent(state3, user3, new DateTime(2020, 11, 08, 12, 2, 0));
            Assert.AreEqual(repository.GetEventsNumber(), 3);
            repository.RemoveAllEvents();
            Assert.AreEqual(repository.GetEventsNumber(), 0);
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            Catalog catalog1 = new Catalog("Frank Herbert");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
            State state2 = new State(catalog2, "Krol");
            User user2 = new User("Michael Johnson");
            Catalog catalog3 = new Catalog("Michel Houellebecq");
            State state3 = new State(catalog3, "Serotonin");
            User user3 = new User("James Martinez");
            repository.AddBorrowEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddBorrowEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            repository.AddBorrowEvent(state3, user3, new DateTime(2020, 11, 08, 12, 2, 0));
            List<AbstractEvent> events = repository.GetAllEvents();
            Assert.AreEqual(repository.GetEventsNumber(), 3);
            Assert.AreEqual(events.Count, 3);
            Assert.IsTrue(events.Exists(n => n.Time == new DateTime(2020, 11, 08, 12, 0, 0)));
            Assert.IsTrue(events.Exists(n => n.Time == new DateTime(2020, 11, 08, 12, 1, 0)));
            Assert.IsTrue(events.Exists(n => n.Time == new DateTime(2020, 11, 08, 12, 2, 0)));
            Assert.IsFalse(events.Exists(n => n.Time == new DateTime(2021, 11, 08, 12, 2, 0)));
        }

        [TestMethod]
        public void CheckBorrowAndReturnEventsTest()
        {
            Catalog catalog1 = new Catalog("Frank Herbert");
            State state1 = new State(catalog1, "Dune");
            User user1 = new User("John Smith");
            Assert.IsFalse(state1.IsBorrowed);
            repository.AddBorrowEvent(state1, user1, DateTime.Now);
            Assert.IsTrue(state1.IsBorrowed);
            repository.AddReturnEvent(state1, user1, DateTime.Now);
            Assert.IsFalse(state1.IsBorrowed);

        }

        [TestMethod]
        public void AddAndRemoveStateTest()
        {
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
            Catalog catalog1 = new Catalog("Frank Herbert");
            repository.AddState(catalog1, "Dune");
            Catalog catalog2 = new Catalog("Szczepan Twardoch");
            repository.AddState(catalog2, "Krol");
            Catalog catalog3 = new Catalog("Michel Houellebecq");
            repository.AddState(catalog3, "Serotonin");
            List<State> states = repository.GetAllStates();
            Assert.AreEqual(repository.GetStatesNumber(), 3);
            Assert.AreEqual(states.Count, 3);
            Assert.IsTrue(states.Exists(n => n.Title == "Dune"));
            Assert.IsTrue(states.Exists(n => n.Title == "Krol"));
            Assert.IsTrue(states.Exists(n => n.Title == "Serotonin"));
            Assert.IsFalse(states.Exists(n => n.Title == "Art of the Deal"));
        }

        [TestMethod]
        public void AddAndRemoveUserTest()
        {
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
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            Assert.AreEqual(repository.GetUsersNumber(), 2);
            repository.AddUser("John Smith");
            Assert.AreEqual(repository.GetUsersNumber(), 2);
        }

        [TestMethod]
        public void RemoveNonExistingUserTest()
        {
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            Assert.AreEqual(repository.GetUsersNumber(), 2);
            repository.RemoveUser(repository.GetUser("James Martinez"));
            Assert.AreEqual(repository.GetUsersNumber(), 2);
        }

        [TestMethod]
        public void RemoveAllUsersTest()
        {
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
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            repository.AddUser("James Martinez");
            List<User> users = repository.GetAllUsers();
            Assert.AreEqual(repository.GetUsersNumber(), 3);
            Assert.AreEqual(users.Count, 3);
            Assert.IsTrue(users.Exists(n => n.Username == "John Smith"));
            Assert.IsTrue(users.Exists(n => n.Username == "Michael Johnson"));
            Assert.IsTrue(users.Exists(n => n.Username == "James Martinez"));
            Assert.IsFalse(users.Exists(n => n.Username == "Edward Ochab"));
        }
    }
}
