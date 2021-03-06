﻿using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class EmptyGenTests
    {
        private IDataRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new DataRepository(EmptyGeneration.Fill(new DataContext()));
        }
        

        [TestMethod]
        public void EmptyGenerationFillTest()
        {
            Assert.IsNull(repository.GetAllCatalogs());
            Assert.IsNull(repository.GetAllEvents());
            Assert.IsNull(repository.GetAllStates());
            Assert.IsNull(repository.GetAllUsers());
        }
    }
}
