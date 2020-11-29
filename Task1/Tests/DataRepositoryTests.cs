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
            repository = new DataRepository(new DataContext());
        }

        [TestMethod]
        public void AddAndRemoveCatalogTest()
        {
            repository.AddCatalog("Dune", "Frank Herbert");
            repository.AddCatalog("Krol", "Szczepan Twardoch");
            Assert.AreEqual(repository.GetCatalogsNumber(), 2);
            repository.RemoveCatalog(repository.GetCatalog("Dune", "Frank Herbert"));
            repository.RemoveCatalog(repository.GetCatalog("Krol", "Szczepan Twardoch"));
            Assert.AreEqual(repository.GetCatalogsNumber(), 0);
        }

        [TestMethod]
        public void GetExistingAndNonExistingCatalogTest()
        {
            repository.AddCatalog("Dune", "Frank Herbert");
            repository.AddCatalog("Krol", "Szczepan Twardoch");
            ICatalog existCatalog = repository.GetCatalog("Dune", "Frank Herbert");
            ICatalog nonExistCatalog = repository.GetCatalog("Serotonin", "Michel Houellebecq");
            Assert.IsNotNull(existCatalog);
            Assert.AreEqual(existCatalog.Author, "Frank Herbert");
            Assert.IsNull(nonExistCatalog);
        }

        [TestMethod]
        public void AddAlreadyExistingCatalogTest()
        {
            repository.AddCatalog("Dune", "Frank Herbert");
            repository.AddCatalog("Krol", "Szczepan Twardoch");
            Assert.AreEqual(repository.GetCatalogsNumber(), 2);
            repository.AddCatalog("Dune", "Frank Herbert");
            Assert.AreEqual(repository.GetCatalogsNumber(), 2);
        }

        [TestMethod]
        public void RemoveNonExistingCatalogTest()
        {
            repository.AddCatalog("Dune", "Frank Herbert");
            repository.AddCatalog("Krol", "Szczepan Twardoch");
            Assert.AreEqual(repository.GetCatalogsNumber(), 2);
            repository.RemoveCatalog(repository.GetCatalog("Serotonin", "Michel Houellebecq"));
            Assert.AreEqual(repository.GetCatalogsNumber(), 2);
        }

        [TestMethod]
        public void RemoveAllCatalogsTest()
        {
            repository.AddCatalog("Dune", "Frank Herbert");
            repository.AddCatalog("Krol", "Szczepan Twardoch");
            repository.AddCatalog("Serotonin", "Michel Houellebecq");
            Assert.AreEqual(repository.GetCatalogsNumber(), 3);
            repository.RemoveAllCatalogs();
            Assert.AreEqual(repository.GetCatalogsNumber(), 0);
        }

        [TestMethod]
        public void GetAllCatalogsTest()
        {
            repository.AddCatalog("Dune", "Frank Herbert");
            repository.AddCatalog("Krol", "Szczepan Twardoch");
            repository.AddCatalog("Serotonin", "Michel Houellebecq");
            List<ICatalog> catalogs = repository.GetAllCatalogs();
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
            ICatalog catalog1 = new Catalog("Dune", "Frank Herbert");
            IState state1 = new State(catalog1, 1);
            IUser user1 = new User("John Smith");
            ICatalog catalog2 = new Catalog("Krol", "Szczepan Twardoch");
            IState state2 = new State(catalog2, 2);
            IUser user2 = new User("Michael Johnson");
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
            ICatalog catalog1 = new Catalog("Dune", "Frank Herbert");
            IState state1 = new State(catalog1, 1);
            IUser user1 = new User("John Smith");
            ICatalog catalog2 = new Catalog("Krol", "Szczepan Twardoch");
            IState state2 = new State(catalog2, 2);
            IUser user2 = new User("Michael Johnson");
            repository.AddBorrowEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddBorrowEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            AbstractEvent existEvent = repository.GetEvent(new DateTime(2020, 11, 08, 12, 0, 0), "John Smith");
            AbstractEvent nonExistEvent = repository.GetEvent(new DateTime(2021, 11, 08, 12, 0, 0), "Michel Houellebecq");
            Assert.IsNotNull(existEvent);
            Assert.AreEqual(existEvent.Time, new DateTime(2020, 11, 08, 12, 0, 0));
            Assert.IsNull(nonExistEvent);
        }

        [TestMethod]
        public void RemoveNonExistingEventTest()
        {
            ICatalog catalog1 = new Catalog("Dune", "Frank Herbert");
            IState state1 = new State(catalog1, 1);
            IUser user1 = new User("John Smith");
            ICatalog catalog2 = new Catalog("Krol", "Szczepan Twardoch");
            IState state2 = new State(catalog2, 2);
            IUser user2 = new User("Michael Johnson");
            repository.AddBorrowEvent(state1, user1, new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddBorrowEvent(state2, user2, new DateTime(2020, 11, 08, 12, 1, 0));
            Assert.AreEqual(repository.GetEventsNumber(), 2);
            repository.RemoveEvent(repository.GetEvent(new DateTime(2021, 11, 08, 12, 0, 0), "Michel Houellebecq"));
            Assert.AreEqual(repository.GetEventsNumber(), 2);
        }

        [TestMethod]
        public void RemoveAllEventsTest()
        {
            ICatalog catalog1 = new Catalog("Dune", "Frank Herbert");
            IState state1 = new State(catalog1, 1);
            IUser user1 = new User("John Smith");
            ICatalog catalog2 = new Catalog("Krol", "Szczepan Twardoch");
            IState state2 = new State(catalog2, 2);
            IUser user2 = new User("Michael Johnson");
            ICatalog catalog3 = new Catalog("Serotonin", "Michel Houellebecq");
            IState state3 = new State(catalog3, 3);
            IUser user3 = new User("James Martinez");
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
            ICatalog catalog1 = new Catalog("Dune", "Frank Herbert");
            IState state1 = new State(catalog1, 1);
            IUser user1 = new User("John Smith");
            ICatalog catalog2 = new Catalog("Krol", "Szczepan Twardoch");
            IState state2 = new State(catalog2, 2);
            IUser user2 = new User("Michael Johnson");
            ICatalog catalog3 = new Catalog("Serotonin", "Michel Houellebecq");
            IState state3 = new State(catalog3, 3);
            IUser user3 = new User("James Martinez");
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
            ICatalog catalog1 = new Catalog("Dune", "Frank Herbert");
            IState state1 = new State(catalog1, 1);
            IUser user1 = new User("John Smith");
            Assert.IsFalse(state1.IsBorrowed);
            repository.AddBorrowEvent(state1, user1, DateTime.Now);
            Assert.IsTrue(state1.IsBorrowed);
            repository.AddReturnEvent(state1, user1, DateTime.Now);
            Assert.IsFalse(state1.IsBorrowed);

        }

        [TestMethod]
        public void AddAndRemoveStateTest()
        {
            ICatalog catalog1 = new Catalog("Dune", "Frank Herbert");
            repository.AddState(catalog1, 1);
            ICatalog catalog2 = new Catalog("Krol", "Szczepan Twardoch");
            repository.AddState(catalog2, 2);
            Assert.AreEqual(repository.GetStatesNumber(), 2);
            repository.RemoveState(repository.GetState(1));
            repository.RemoveState(repository.GetState(2));
            Assert.AreEqual(repository.GetStatesNumber(), 0);
        }

        [TestMethod]
        public void GetExistingAndNonExistingStateTest()
        {
            ICatalog catalog1 = new Catalog("Dune", "Frank Herbert");
            repository.AddState(catalog1, 1);
            ICatalog catalog2 = new Catalog("Krol", "Szczepan Twardoch");
            repository.AddState(catalog2, 2);
            IState existState = repository.GetState(1);
            IState nonExistState = repository.GetState(3);
            Assert.IsNotNull(existState);
            Assert.AreEqual(existState.ID, 1);
            Assert.IsNull(nonExistState);
        }

        [TestMethod]
        public void AddAlreadyExistingStateTest()
        {
            ICatalog catalog1 = new Catalog("Dune", "Frank Herbert");
            repository.AddState(catalog1, 1);
            ICatalog catalog2 = new Catalog("Krol", "Szczepan Twardoch");
            repository.AddState(catalog2, 2);
            Assert.AreEqual(repository.GetStatesNumber(), 2);
            ICatalog catalog3 = new Catalog("Dune", "Frank Herbert");
            repository.AddState(catalog3, 1);
            Assert.AreEqual(repository.GetStatesNumber(), 2);
        }

        [TestMethod]
        public void RemoveNonExistingStateTest()
        {
            ICatalog catalog1 = new Catalog("Dune", "Frank Herbert");
            repository.AddState(catalog1, 1);
            ICatalog catalog2 = new Catalog("Krol", "Szczepan Twardoch");
            repository.AddState(catalog2, 2);
            Assert.AreEqual(repository.GetStatesNumber(), 2);
            repository.RemoveState(repository.GetState(3));
            Assert.AreEqual(repository.GetStatesNumber(), 2);
        }

        [TestMethod]
        public void RemoveAllStatesTest()
        {
            ICatalog catalog1 = new Catalog("Dune", "Frank Herbert");
            repository.AddState(catalog1, 1);
            ICatalog catalog2 = new Catalog("Krol", "Szczepan Twardoch");
            repository.AddState(catalog2, 2);
            ICatalog catalog3 = new Catalog("Serotonin", "Michel Houellebecq");
            repository.AddState(catalog3, 3);
            Assert.AreEqual(repository.GetStatesNumber(), 3);
            repository.RemoveAllStates();
            Assert.AreEqual(repository.GetStatesNumber(), 0);
        }

        [TestMethod]
        public void GetAllStatesTest()
        {
            ICatalog catalog1 = new Catalog("Dune", "Frank Herbert");
            repository.AddState(catalog1, 1);
            ICatalog catalog2 = new Catalog("Krol", "Szczepan Twardoch");
            repository.AddState(catalog2, 2);
            ICatalog catalog3 = new Catalog("Serotonin", "Michel Houellebecq");
            repository.AddState(catalog3, 3);
            List<IState> states = repository.GetAllStates();
            Assert.AreEqual(repository.GetStatesNumber(), 3);
            Assert.AreEqual(states.Count, 3);
            Assert.IsTrue(states.Exists(n => n.ID == 1));
            Assert.IsTrue(states.Exists(n => n.ID == 2));
            Assert.IsTrue(states.Exists(n => n.ID == 3));
            Assert.IsFalse(states.Exists(n => n.ID == 4));
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
            IUser existUser = repository.GetUser("John Smith");
            IUser nonExistUser = repository.GetUser("James Martinez");
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
            List<IUser> users = repository.GetAllUsers();
            Assert.AreEqual(repository.GetUsersNumber(), 3);
            Assert.AreEqual(users.Count, 3);
            Assert.IsTrue(users.Exists(n => n.Username == "John Smith"));
            Assert.IsTrue(users.Exists(n => n.Username == "Michael Johnson"));
            Assert.IsTrue(users.Exists(n => n.Username == "James Martinez"));
            Assert.IsFalse(users.Exists(n => n.Username == "Edward Ochab"));
        }
    }
}
