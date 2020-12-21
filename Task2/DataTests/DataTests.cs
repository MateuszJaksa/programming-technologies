using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTests
{
    [TestClass]
    public class DataTests
    {
        private const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\\LibraryDatabase.mdf;Integrated Security=True";
      
        [TestMethod]
        public void AddToAndGetFromDatabaseTest()
        {
            LinqToSqlDataContext dataContext = new LinqToSqlDataContext();

            Catalogs createdCatalog = new Catalogs
            {
                Author = "Friedrich Nietzsche",
                Title = "Thus Spoke Zarathustra"
            };

            dataContext.Catalogs.InsertOnSubmit(createdCatalog);
            dataContext.SubmitChanges();

            Catalogs readCatalog1 = dataContext.Catalogs.FirstOrDefault(catalog => catalog.Title == "Thus Spoke Zarathustra");
            Catalogs readCatalog2 = dataContext.Catalogs.FirstOrDefault(catalog => catalog.Title == "Also Sprach Zarathustra");

            Assert.AreEqual(readCatalog1.Title, "Thus Spoke Zarathustra");
            Assert.AreEqual(readCatalog1.Author, "Friedrich Nietzsche");
            Assert.IsNull(readCatalog2);

            dataContext.Catalogs.DeleteOnSubmit(createdCatalog);
            dataContext.SubmitChanges();
        }
    }
}
