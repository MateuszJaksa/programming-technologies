using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Data;

namespace Tests
{
    [TestClass]
    public class LibraryRepositoryTests
    {
        private LibraryRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new LibraryRepository();
            repository.RemoveAllEvents();
            repository.RemoveAllStates();
            repository.RemoveAllUsers();
            repository.RemoveAllCatalogs();
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
            Catalogs existCatalog = repository.GetCatalog("Dune", "Frank Herbert");
            Catalogs nonExistCatalog = repository.GetCatalog("Serotonin", "Michel Houellebecq");
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
            List<Catalogs> catalogs = repository.GetAllCatalogs();
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
            repository.AddCatalog("Dune", "Frank Herbert");
            repository.AddCatalog("Krol", "Szczepan Twardoch");
            int id1 = repository.AddState(repository.GetCatalog("Dune", "Frank Herbert"));
            int id2 = repository.AddState(repository.GetCatalog("Krol", "Szczepan Twardoch"));
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            repository.AddBorrowEvent(repository.GetState(id1), repository.GetUser("John Smith"), new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddBorrowEvent(repository.GetState(id2), repository.GetUser("Michael Johnson"), new DateTime(2020, 11, 08, 12, 1, 0));
            Assert.AreEqual(repository.GetEventsNumber(), 2);
            repository.RemoveEvent(repository.GetEvent(new DateTime(2020, 11, 08, 12, 0, 0), "John Smith"));
            repository.RemoveEvent(repository.GetEvent(new DateTime(2020, 11, 08, 12, 1, 0), "Michael Johnson"));
            Assert.AreEqual(repository.GetEventsNumber(), 0);
        }

        [TestMethod]
        public void GetExistingAndNonExistingEventTest()
        {
            repository.AddCatalog("Dune", "Frank Herbert");
            repository.AddCatalog("Krol", "Szczepan Twardoch");
            int id1 = repository.AddState(repository.GetCatalog("Dune", "Frank Herbert"));
            int id2 = repository.AddState(repository.GetCatalog("Krol", "Szczepan Twardoch"));
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            repository.AddBorrowEvent(repository.GetState(id1), repository.GetUser("John Smith"), new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddBorrowEvent(repository.GetState(id2), repository.GetUser("Michael Johnson"), new DateTime(2020, 11, 08, 12, 1, 0));
            LibraryEvents existEvent = repository.GetEvent(new DateTime(2020, 11, 08, 12, 0, 0), "John Smith");
            LibraryEvents nonExistEvent = repository.GetEvent(new DateTime(2021, 11, 08, 12, 0, 0), "Michel Houellebecq");
            Assert.IsNotNull(existEvent);
            Assert.AreEqual(existEvent.Time, new DateTime(2020, 11, 08, 12, 0, 0));
            Assert.IsNull(nonExistEvent);
        }

        [TestMethod]
        public void RemoveNonExistingEventTest()
        {
            repository.AddCatalog("Dune", "Frank Herbert");
            repository.AddCatalog("Krol", "Szczepan Twardoch");
            int id1 = repository.AddState(repository.GetCatalog("Dune", "Frank Herbert"));
            int id2 = repository.AddState(repository.GetCatalog("Krol", "Szczepan Twardoch"));
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            repository.AddBorrowEvent(repository.GetState(id1), repository.GetUser("John Smith"), new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddBorrowEvent(repository.GetState(id2), repository.GetUser("Michael Johnson"), new DateTime(2020, 11, 08, 12, 1, 0));
            Assert.AreEqual(repository.GetEventsNumber(), 2);
            repository.RemoveEvent(repository.GetEvent(new DateTime(2021, 11, 08, 12, 0, 0), "Michel Houellebecq"));
            Assert.AreEqual(repository.GetEventsNumber(), 2);
        }

        [TestMethod]
        public void RemoveAllEventsTest()
        {
            repository.AddCatalog("Dune", "Frank Herbert");
            repository.AddCatalog("Krol", "Szczepan Twardoch");
            repository.AddCatalog("Serotonin", "Michel Houellebecq");
            int id1 = repository.AddState(repository.GetCatalog("Dune", "Frank Herbert"));
            int id2 = repository.AddState(repository.GetCatalog("Krol", "Szczepan Twardoch"));
            int id3 = repository.AddState(repository.GetCatalog("Serotonin", "Michel Houellebecq"));
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            repository.AddUser("James Martinez");
            repository.AddBorrowEvent(repository.GetState(id1), repository.GetUser("John Smith"), new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddBorrowEvent(repository.GetState(id2), repository.GetUser("Michael Johnson"), new DateTime(2020, 11, 08, 12, 1, 0));
            repository.AddBorrowEvent(repository.GetState(id3), repository.GetUser("James Martinez"), new DateTime(2020, 11, 08, 12, 2, 0));
            Assert.AreEqual(repository.GetEventsNumber(), 3);
            repository.RemoveAllEvents();
            Assert.AreEqual(repository.GetEventsNumber(), 0);
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            repository.AddCatalog("Dune", "Frank Herbert");
            repository.AddCatalog("Krol", "Szczepan Twardoch");
            repository.AddCatalog("Serotonin", "Michel Houellebecq");
            int id1 = repository.AddState(repository.GetCatalog("Dune", "Frank Herbert"));
            int id2 = repository.AddState(repository.GetCatalog("Krol", "Szczepan Twardoch"));
            int id3 = repository.AddState(repository.GetCatalog("Serotonin", "Michel Houellebecq"));
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            repository.AddUser("James Martinez");
            repository.AddBorrowEvent(repository.GetState(id1), repository.GetUser("John Smith"), new DateTime(2020, 11, 08, 12, 0, 0));
            repository.AddBorrowEvent(repository.GetState(id2), repository.GetUser("Michael Johnson"), new DateTime(2020, 11, 08, 12, 1, 0));
            repository.AddBorrowEvent(repository.GetState(id3), repository.GetUser("James Martinez"), new DateTime(2020, 11, 08, 12, 2, 0));
            List<LibraryEvents> events = repository.GetAllEvents();
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
            repository.AddCatalog("Dune", "Frank Herbert");
            int id1 = repository.AddState(repository.GetCatalog("Dune", "Frank Herbert"));
            repository.AddUser("John Smith");
            repository.AddBorrowEvent(repository.GetState(id1), repository.GetUser("John Smith"), DateTime.Now);
            Assert.IsTrue((bool)repository.GetState(id1).IsBorrowed);
            repository.AddReturnEvent(repository.GetState(id1), repository.GetUser("John Smith"), DateTime.Now);
            Assert.IsFalse((bool)repository.GetState(id1).IsBorrowed);
        }

        [TestMethod]
        public void AddAndRemoveStateTest()
        {
            repository.AddCatalog("Dune", "Frank Herbert");
            repository.AddCatalog("Krol", "Szczepan Twardoch");
            int id1 = repository.AddState(repository.GetCatalog("Dune", "Frank Herbert"));
            int id2 = repository.AddState(repository.GetCatalog("Krol", "Szczepan Twardoch"));
            Assert.AreEqual(repository.GetStatesNumber(), 2);
            repository.RemoveState(repository.GetState(id1));
            repository.RemoveState(repository.GetState(id2));
            Assert.AreEqual(repository.GetStatesNumber(), 0);
        }

        [TestMethod]
        public void GetExistingAndNonExistingStateTest()
        {
            repository.AddCatalog("Dune", "Frank Herbert");
            repository.AddCatalog("Krol", "Szczepan Twardoch");
            int id1 = repository.AddState(repository.GetCatalog("Dune", "Frank Herbert"));
            repository.AddState(repository.GetCatalog("Krol", "Szczepan Twardoch"));
            States existState = repository.GetState(id1);
            States nonExistState = repository.GetState(-1);
            Assert.IsNotNull(existState);
            Assert.AreEqual(existState.ID, id1);
            Assert.IsNull(nonExistState);
        }

        [TestMethod]
        public void RemoveNonExistingStateTest()
        {
            repository.AddCatalog("Dune", "Frank Herbert");
            repository.AddCatalog("Krol", "Szczepan Twardoch");
            repository.AddState(repository.GetCatalog("Dune", "Frank Herbert"));
            repository.AddState(repository.GetCatalog("Krol", "Szczepan Twardoch"));
            Assert.AreEqual(repository.GetStatesNumber(), 2);
            repository.RemoveState(repository.GetState(3));
            Assert.AreEqual(repository.GetStatesNumber(), 2);
        }

        [TestMethod]
        public void RemoveAllStatesTest()
        {
            repository.AddCatalog("Dune", "Frank Herbert");
            repository.AddCatalog("Krol", "Szczepan Twardoch");
            repository.AddCatalog("Serotonin", "Michel Houellebecq");
            repository.AddState(repository.GetCatalog("Dune", "Frank Herbert"));
            repository.AddState(repository.GetCatalog("Krol", "Szczepan Twardoch"));
            repository.AddState(repository.GetCatalog("Serotonin", "Michel Houellebecq"));
            Assert.AreEqual(repository.GetStatesNumber(), 3);
            repository.RemoveAllStates();
            Assert.AreEqual(repository.GetStatesNumber(), 0);
        }

        [TestMethod]
        public void GetAllStatesTest()
        {
            repository.AddCatalog("Dune", "Frank Herbert");
            repository.AddCatalog("Krol", "Szczepan Twardoch");
            repository.AddCatalog("Serotonin", "Michel Houellebecq");
            int id1 = repository.AddState(repository.GetCatalog("Dune", "Frank Herbert"));
            int id2 = repository.AddState(repository.GetCatalog("Krol", "Szczepan Twardoch"));
            int id3 = repository.AddState(repository.GetCatalog("Serotonin", "Michel Houellebecq"));
            List<States> states = repository.GetAllStates();
            Assert.AreEqual(repository.GetStatesNumber(), 3);
            Assert.AreEqual(states.Count, 3);
            Assert.IsTrue(states.Exists(n => n.ID == id1));
            Assert.IsTrue(states.Exists(n => n.ID == id2));
            Assert.IsTrue(states.Exists(n => n.ID == id3));
            Assert.IsFalse(states.Exists(n => n.ID == -1));
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
            Users existUser = repository.GetUser("John Smith");
            Users nonExistUser = repository.GetUser("James Martinez");
            Assert.IsNotNull(existUser);
            Assert.AreEqual(existUser.Name, "John Smith");
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
            List<Users> users = repository.GetAllUsers();
            Assert.AreEqual(repository.GetUsersNumber(), 3);
            Assert.AreEqual(users.Count, 3);
            Assert.IsTrue(users.Exists(n => n.Name == "John Smith"));
            Assert.IsTrue(users.Exists(n => n.Name == "Michael Johnson"));
            Assert.IsTrue(users.Exists(n => n.Name == "James Martinez"));
            Assert.IsFalse(users.Exists(n => n.Name == "Edward Ochab"));
        }
    }
}
