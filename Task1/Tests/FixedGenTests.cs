using System;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FixedGenTests
    {
        private IDataRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new DataRepository(FixedGeneration.Fill(new DataContext()));
        }


        [TestMethod]
        public void FixedGenerationFillCountTest()
        {
            Assert.AreEqual(repository.GetCatalogsNumber(), 4);
            Assert.AreEqual(repository.GetEventsNumber(), 5);
            Assert.AreEqual(repository.GetStatesNumber(), 5);
            Assert.AreEqual(repository.GetUsersNumber(), 4);
        }

        [TestMethod]
        public void FixedGenerationElementsTest()
        {
            Assert.IsNull(repository.GetCatalog("Art of the Deal", "Donald Trump"));
            Assert.IsNotNull(repository.GetCatalog("Les Miserables", "Victor Hugo"));
            Assert.IsNull(repository.GetEvent(new DateTime(2021, 01, 01, 12, 0, 0), "Edward Ochab"));
            Assert.IsNotNull(repository.GetEvent(new DateTime(2020, 10, 11, 12, 0, 0), "Tadeusz Chrostowski"));
            Assert.IsNull(repository.GetState(12));
            Assert.IsNotNull(repository.GetState(11));
            Assert.IsNull(repository.GetUser("Marian Spychalski"));
            Assert.IsNotNull(repository.GetUser("Tadeusz Chrostowski"));
        }
    }
}
