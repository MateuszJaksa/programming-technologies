using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            repository = new DataRepository(new FixedGeneration());
            repository.Fill();
        }


        [TestMethod]
        public void FixedGenerationFillCountTest()
        {
            Assert.AreEqual(repository.GetCatalogsNumber(), 4);
            Assert.AreEqual(repository.GetEventsNumber(), 6);
            Assert.AreEqual(repository.GetStatesNumber(), 5);
            Assert.AreEqual(repository.GetUsersNumber(), 4);
        }

        [TestMethod]
        public void FixedGenerationElementsTest()
        {
            Assert.IsNull(repository.GetCatalog("Donald Trump"));
            Assert.IsNotNull(repository.GetCatalog("Victor Hugo"));
            Assert.IsNull(repository.GetEvent(new DateTime(2021, 01, 01, 12, 0, 0), "Edward Ochab"));
            Assert.IsNotNull(repository.GetEvent(new DateTime(2020, 10, 11, 12, 0, 0), "Tadeusz Chrostowski"));
            Assert.IsNull(repository.GetState("Art of the Deal"));
            Assert.IsNotNull(repository.GetState("The Emperor"));
            Assert.IsNull(repository.GetUser("Marian Spychalski"));
            Assert.IsNotNull(repository.GetUser("Tadeusz Chrostowski"));
        }
    }
}
