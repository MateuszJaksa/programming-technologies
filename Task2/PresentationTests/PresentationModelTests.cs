using System;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Model;
using Services;

namespace PresentationTests
{
    [TestClass]
    public class PresentationModelTests
    {
        [TestMethod]
        public void TestCatalogModel()
        {
            LibraryRepository repository = new LibraryRepository();
            ObservableCollection<CatalogModel> models = CatalogModel.GetCatalogs();
            Assert.AreEqual(repository.GetAllCatalogIds().Count, models.Count);
            foreach (CatalogModel model in models)
            {
                Assert.IsTrue(repository.GetAllCatalogIds().Exists(id => id == model.Id));
            }
        }

        [TestMethod]
        public void TestStateModel()
        {
            LibraryRepository repository = new LibraryRepository();
            ObservableCollection<StateModel> models = StateModel.GetStates();
            Assert.AreEqual(repository.GetAllStateIds().Count, models.Count);
            foreach (StateModel model in models)
            {
                Assert.IsTrue(repository.GetAllStateIds().Exists(id => id == model.Id));
            }
        }
    }
}
