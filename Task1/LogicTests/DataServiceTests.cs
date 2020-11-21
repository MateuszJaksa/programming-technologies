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
        private static readonly int id = 27;

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
            HashSet<ICatalog> oldSet = new HashSet<ICatalog>(service.GetCatalogs());
            ICatalog catalog = new Catalog(title, author);
            oldSet.Add(catalog);
            service.AddCatalog(title, author);
            HashSet<ICatalog> newSet = new HashSet<ICatalog>(service.GetCatalogs());
            Assert.IsTrue(newSet.SetEquals(oldSet));
            IList<ICatalog> catalogs = service.GetCatalogs(author);
            Assert.IsTrue(catalogs.Count == 1);
            Assert.IsTrue(catalog.Equals(catalogs[0]));
        }

        [TestMethod]
        public void TestRemoveCatalog()
        {
            IList<ICatalog> oldList = service.GetCatalogs();
            ICatalog deletedCatalog = oldList[0];
            oldList.Remove(deletedCatalog);
            service.RemoveCatalog(deletedCatalog);
            HashSet<ICatalog> newSet = new HashSet<ICatalog>(service.GetCatalogs());
            Assert.IsTrue(newSet.SetEquals(new HashSet<ICatalog>(oldList)));
            IList<ICatalog> catalogs = service.GetCatalogs(deletedCatalog.Author);
            Assert.IsTrue(catalogs.Count == 0);
        }

        [TestMethod]
        public void TestAddState()
        {
            service.AddCatalog(title, author);
            ICatalog catalog = service.GetCatalogs(author)[0];

            HashSet<IState> oldStates = new HashSet<IState>(service.GetStates());
            IState state = new State(catalog, id);
            oldStates.Add(state);
            service.AddState(catalog, id);

            HashSet<IState> newStates = new HashSet<IState>(service.GetStates());
            Assert.IsTrue(newStates.SetEquals(oldStates));
        }

        [TestMethod]
        public void TestRemoveState()
        {
            IList<IState> oldList = service.GetStates();
            IState deletedState = oldList[0];
            oldList.Remove(deletedState);
            service.RemoveState(deletedState);
            HashSet<IState> newSet = new HashSet<IState>(service.GetStates());
            Assert.IsTrue(newSet.SetEquals(new HashSet<IState>(oldList)));
            IList<IState> state = service.GetStates(deletedState.ID);
            Assert.IsTrue(state.Count == 0);
        }

        [TestMethod]
        public void TestSearchStateByAuthor()
        {
            service.AddCatalog(title, author);
            ICatalog catalog = service.GetCatalogs(author)[0];
            service.AddState(catalog, id);
            IList<IState> states = service.SearchStatesByAuthor(lastName);
            Assert.IsTrue(states.Count == 1);
            Assert.IsTrue(states[0].Catalog.Author == author);
        }

        [TestMethod]
        public void TestAddUser()
        {
            HashSet<IUser> oldSet = new HashSet<IUser>(service.GetUsers());
            IUser user = new User(username);
            oldSet.Add(user);
            service.AddUser(username);
            HashSet<IUser> newSet = new HashSet<IUser>(service.GetUsers());
            Assert.IsTrue(newSet.SetEquals(oldSet));
            IList<IUser> users = service.GetUsers(username);
            Assert.IsTrue(users.Count == 1);
            Assert.IsTrue(user.Equals(users[0]));
        }

        [TestMethod]
        public void TestRemoveUser()
        {
            IList<IUser> oldList = service.GetUsers();
            IUser deletedUser = oldList[0];
            oldList.Remove(deletedUser);
            service.RemoveUser(deletedUser);
            HashSet<IUser> newSet = new HashSet<IUser>(service.GetUsers());
            Assert.IsTrue(newSet.SetEquals(new HashSet<IUser>(oldList)));
            IList<IUser> users = service.GetUsers(deletedUser.Username);
            Assert.IsTrue(users.Count == 0);
        }

        [TestMethod]
        public void TestBorrowAndReturn()
        {
            Console.WriteLine("here");
            service.AddCatalog(title, author);
            ICatalog catalog = service.GetCatalogs(author)[0];
            service.AddState(catalog, id);
            IState state = service.GetStates(id)[0];
            service.AddUser(username);
            IUser user = service.GetUsers(username)[0];
            Assert.IsFalse(state.IsBorrowed);

            service.Borrow(state, user);
            Assert.IsTrue(state.IsBorrowed);

            service.Return(state, user);
            Assert.IsFalse(state.IsBorrowed);
        }

        [TestMethod]
        public void TestEventsByTime()
        {
            service.AddCatalog(title, author);
            ICatalog catalog = service.GetCatalogs()[0];
            service.AddState(catalog, id);
            IState state = service.GetStates(id)[0];
            service.AddUser(username);
            IUser user = service.GetUsers(username)[0];
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
