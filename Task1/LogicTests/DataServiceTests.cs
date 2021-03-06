﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Data;
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
            service = new DataService(new DataRepository(new DataContext()));
        }

        [TestMethod]
        public void TestAddCatalog()
        {
            HashSet<ICatalog> oldSet = new HashSet<ICatalog>();
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
            service.AddCatalog(title, author);
            service.AddCatalog(title + " Plenus", author);
            IList<ICatalog> oldList = service.GetCatalogs();
            Assert.IsTrue(oldList.Count == 2);
            ICatalog deletedCatalog = oldList[0];
            oldList.Remove(deletedCatalog);
            service.RemoveCatalog(deletedCatalog);
            Assert.IsTrue(service.GetCatalogs().Count == 1);
            HashSet<ICatalog> newSet = new HashSet<ICatalog>(service.GetCatalogs());
            Assert.IsTrue(newSet.SetEquals(new HashSet<ICatalog>(oldList)));
        }

        [TestMethod]
        public void TestAddState()
        {
            service.AddCatalog(title, author);
            ICatalog catalog = service.GetCatalogs(author)[0];
            service.AddState(catalog, id + 1);

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
            service.AddCatalog(title, author);
            ICatalog catalog = service.GetCatalogs(author)[0];
            service.AddState(catalog, id);
            service.AddState(catalog, id + 1);
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
            service.AddUser(username + "1");
            HashSet<IUser> oldSet = new HashSet<IUser>(service.GetUsers());
            IUser user = new User(username);
            oldSet.Add(user);
            service.AddUser(username);
            HashSet<IUser> newSet = new HashSet<IUser>(service.GetUsers());
            Assert.IsTrue(newSet.SetEquals(oldSet));
        }

        [TestMethod]
        public void TestRemoveUser()
        {
            service.AddUser(username);
            service.AddUser(username + "1");
            IList<IUser> oldList = service.GetUsers();
            IUser deletedUser = oldList[0];
            oldList.Remove(deletedUser);
            service.RemoveUser(deletedUser);
            HashSet<IUser> newSet = new HashSet<IUser>(service.GetUsers());
            Assert.IsTrue(newSet.SetEquals(new HashSet<IUser>(oldList)));
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
