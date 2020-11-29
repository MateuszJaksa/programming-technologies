using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class RandomGenTests
    {
        private IDataRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new DataRepository(RandomGeneration.Fill(new DataContext()));
        }


        [TestMethod]
        public void RandomGenerationFillTest()
        {
            Assert.AreEqual(repository.GetCatalogsNumber(), 8);
            Assert.AreEqual(repository.GetEventsNumber(), 8);
            Assert.AreEqual(repository.GetStatesNumber(), 8);
            Assert.AreEqual(repository.GetUsersNumber(), 8);
        }
    }
}
