using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;

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
            repository.RemoveAllStates();
            repository.RemoveAllCatalogs();
        }

        [TestMethod]
        public void AddAndRemoveCatalogTest()
        {
            int int1 = repository.AddCatalog("Dune", "Frank Herbert");
            int int2 = repository.AddCatalog("Krol", "Szczepan Twardoch");
            Assert.AreEqual(repository.GetAllCatalogIds().Count, 2);
            repository.RemoveCatalog(int1);
            repository.RemoveCatalog(int2);
            Assert.AreEqual(repository.GetAllCatalogIds().Count, 0);
        }

        [TestMethod]
        public void GetAndUpdateCatalogTest()
        {
            int int1 = repository.AddCatalog("Dune", "Frank Herbert");
            string title = repository.GetCatalogTitle(int1);
            string author = repository.GetCatalogAuthor(int1);
            Assert.AreEqual(title, "Dune");
            Assert.AreEqual(author, "Frank Herbert");
            repository.UpdateCatalog(int1, "Krol", "Szczepan Twardoch");
            title = repository.GetCatalogTitle(int1);
            author = repository.GetCatalogAuthor(int1);
            Assert.AreEqual(title, "Krol");
            Assert.AreEqual(author, "Szczepan Twardoch");
        }

        [TestMethod]
        public void RemoveAllCatalogsTest()
        {
            repository.AddCatalog("Dune", "Frank Herbert");
            repository.AddCatalog("Krol", "Szczepan Twardoch");
            repository.AddCatalog("Serotonin", "Michel Houellebecq");
            Assert.AreEqual(repository.GetAllCatalogIds().Count, 3);
            repository.RemoveAllCatalogs();
            Assert.AreEqual(repository.GetAllCatalogIds().Count, 0);
        }

        [TestMethod]
        public void AddAndRemoveStateTest()
        {
            int int1 = repository.AddCatalog("Dune", "Frank Herbert");
            int int2 = repository.AddCatalog("Krol", "Szczepan Twardoch");
            int id1 = repository.AddState(int1, false);
            int id2 = repository.AddState(int2, false);
            Assert.AreEqual(repository.GetAllStateIds().Count, 2);
            repository.RemoveState(id1);
            repository.RemoveState(id2);
            Assert.AreEqual(repository.GetAllStateIds().Count, 0); ;
        }

        [TestMethod]
        public void GetAndUpdateStateTest()
        {
            int int1 = repository.AddCatalog("Dune", "Frank Herbert");
            int int2 = repository.AddCatalog("Krol", "Szczepan Twardoch");
            int id1 = repository.AddState(int1, false);
            bool isBorrowed = repository.GetStateIsBorrowed(id1);
            int catalogId = repository.GetStateCatalogId(id1);
            Assert.AreEqual(isBorrowed, false);
            Assert.AreEqual(catalogId, int1);
            repository.UpdateState(id1, int2, true);
            isBorrowed = repository.GetStateIsBorrowed(id1);
            catalogId = repository.GetStateCatalogId(id1);
            Assert.AreEqual(isBorrowed, true);
            Assert.AreEqual(catalogId, int2);
        }

        [TestMethod]
        public void RemoveAllStatesTest()
        {
            int int1 = repository.AddCatalog("Dune", "Frank Herbert");
            int int2 = repository.AddCatalog("Krol", "Szczepan Twardoch");
            int int3 = repository.AddCatalog("Serotonin", "Michel Houellebecq");
            repository.AddState(int1, false);
            repository.AddState(int2, false);
            repository.AddState(int3, true);
            Assert.AreEqual(repository.GetAllStateIds().Count, 3);
            repository.RemoveAllStates();
            Assert.AreEqual(repository.GetAllStateIds().Count, 0);
        }
    }
}
