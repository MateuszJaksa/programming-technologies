using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class DataRepositoryTest
    {
        private DataContext context;
        private DataRepository repository;

        [TestMethod]
        public void AddAndRemoveUserTest()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);
            repository.AddUser("John Smith");
            repository.AddUser("Michael Johnson");
            Assert.AreEqual(context.users.Count, 2);
            repository.RemoveUser("John Smith");
            repository.RemoveUser("Michael Johnson");
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
            Assert.AreEqual(existUser.UserName, "John Smith");
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
            repository.RemoveUser("James Martinez");
            Assert.AreEqual(context.users.Count, 2);
        }

        [TestMethod]
        public void RemoveAllUserTest()
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
            Assert.AreEqual(users[0].UserName, "John Smith");
            Assert.AreEqual(users[1].UserName, "Michael Johnson");
            Assert.AreEqual(users[2].UserName, "James Martinez");
        }
    }
}
