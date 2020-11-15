using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Data;
using Generation;
using Logic;

namespace LogicTests
{
    [TestClass]
    public class DataServiceTests
    {

        private DataService service;
        private static readonly string lastName = "Agricola";
        private static readonly string author = "Georg " + lastName;
        private static readonly string username = "Shen Kuo";
        private static readonly string title = "De Re Metallica";

        [TestInitialize]
        public void Initialize()
        {
            IGeneration generation = new FixedGeneration();
            IDataRepository repository = new DataRepository(generation);
            repository.Fill();
            service = new DataService(repository);
        }

        [TestMethod]
        public void TestAddCatalog()
        {
            HashSet<Catalog> oldSet = new HashSet<Catalog>(service.GetCatalogs());
            Catalog catalog = new Catalog(author);
            oldSet.Add(catalog);
            service.AddCatalog(author);
            HashSet<Catalog> newSet = new HashSet<Catalog>(service.GetCatalogs());
            Assert.IsTrue(newSet.SetEquals(oldSet));
            IList<Catalog> catalogs = service.GetCatalogs(author);
            Assert.IsTrue(catalogs.Count == 1);
            Assert.IsTrue(catalog.Equals(catalogs[0]));
        }

        [TestMethod]
        public void TestRemoveCatalog()
        {
            IList<Catalog> oldList = service.GetCatalogs();
            Catalog deletedCatalog = oldList[0];
            oldList.Remove(deletedCatalog);
            service.RemoveCatalog(deletedCatalog);
            HashSet<Catalog> newSet = new HashSet<Catalog>(service.GetCatalogs());
            Assert.IsTrue(newSet.SetEquals(new HashSet<Catalog>(oldList)));
            IList<Catalog> catalogs = service.GetCatalogs(deletedCatalog.Author);
            Assert.IsTrue(catalogs.Count == 0);
        }

        [TestMethod]
        public void TestAddState()
        {
            service.AddCatalog(author);
            Catalog catalog = service.GetCatalogs(author)[0];

            HashSet<State> oldStates = new HashSet<State>(service.GetStates());
            State state = new State(catalog, title);
            oldStates.Add(state);
            service.AddState(catalog, title);

            HashSet<State> newStates = new HashSet<State>(service.GetStates());
            Assert.IsTrue(newStates.SetEquals(oldStates));
        }

        [TestMethod]
        public void TestRemoveState()
        {
            IList<State> oldList = service.GetStates();
            State deletedState = oldList[0];
            oldList.Remove(deletedState);
            service.RemoveState(deletedState);
            HashSet<State> newSet = new HashSet<State>(service.GetStates());
            Assert.IsTrue(newSet.SetEquals(new HashSet<State>(oldList)));
            IList<State> state = service.GetStates(deletedState.Title);
            Assert.IsTrue(state.Count == 0);
        }

        [TestMethod]
        public void TestSearchStateByAuthor()
        {
            service.AddCatalog(author);
            Catalog catalog = service.GetCatalogs(author)[0];

            service.AddState(catalog, title);
            IList<State> states = service.SearchStatesByAuthor(lastName);
            Assert.IsTrue(states.Count == 1);
            Assert.IsTrue(states[0].Catalog.Author == author);
        }

        [TestMethod]
        public void TestAddUser()
        {
            HashSet<User> oldSet = new HashSet<User>(service.GetUsers());
            User user = new User(username);
            oldSet.Add(user);
            service.AddUser(username);
            HashSet<User> newSet = new HashSet<User>(service.GetUsers());
            Assert.IsTrue(newSet.SetEquals(oldSet));
            IList<User> users = service.GetUsers(username);
            Assert.IsTrue(users.Count == 1);
            Assert.IsTrue(user.Equals(users[0]));
        }

        [TestMethod]
        public void TestRemoveUser()
        {
            IList<User> oldList = service.GetUsers();
            User deletedUser = oldList[0];
            oldList.Remove(deletedUser);
            service.RemoveUser(deletedUser);
            HashSet<User> newSet = new HashSet<User>(service.GetUsers());
            Assert.IsTrue(newSet.SetEquals(new HashSet<User>(oldList)));
            IList<User> users = service.GetUsers(deletedUser.Username);
            Assert.IsTrue(users.Count == 0);
        }

        [TestMethod]
        public void TestBorrowAndReturn()
        {
            Console.WriteLine("here");
            service.AddCatalog(author);
            Catalog catalog = service.GetCatalogs(author)[0];
            service.AddState(catalog, title);
            State state = service.GetStates(title)[0];
            service.AddUser(username);
            User user = service.GetUsers(username)[0];
            Assert.IsFalse(state.IsBorrowed);

            service.Borrow(state, user);
            Assert.IsTrue(state.IsBorrowed);

            service.Return(state, user);
            Assert.IsFalse(state.IsBorrowed);
        }

        [TestMethod]
        public void TestEventsByTime()
        {
            service.AddCatalog(author);
            Catalog catalog = service.GetCatalogs()[0];
            service.AddState(catalog, title);
            State state = service.GetStates(title)[0];
            service.AddUser(username);
            User user = service.GetUsers(username)[0];
            Assert.IsFalse(state.IsBorrowed);

            service.Borrow(state, user);
            Assert.IsTrue(state.IsBorrowed);
            DateTime startTime = DateTime.Now;

            service.Return(state, user);
            Assert.IsFalse(state.IsBorrowed);
            service.GetEventsByTime(state, startTime, DateTime.Now);
        }

    }
}
