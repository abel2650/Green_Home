using Green_home.Services;
using Microsoft.Data.SqlClient;
using Green_home.Model;
using Moq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Ejendomme = Green_home.Model.Ejendomme;

namespace GreenHomeTest.Services
{
    [TestClass]
    public class EjendommeRepository_DBTest
    {

        private EjendommeRepository_DB repository;
        private List<Ejendomme> ejendommeList = new List<Ejendomme>();

        [TestInitialize]
        public void BeforeEachTest()
        {
            // Arrange: Opsæt mocks og opret instans af repository
            SqlConnection connection = new SqlConnection(Secret.ConnectionString);
            repository = new EjendommeRepository_DB();
            ejendommeList = repository.GetAll(); 
        }

        [TestCleanup]
        public void AfterEachTest()
        {
            ejendommeList = null!; 
        }

        [TestMethod]
        public void TestGetAll_EmptyList()
        {
            // Act: Kald GetAll metoden
            List<Ejendomme> ejendommeList = repository.GetAll();

            // Assert: Verificer at den returnerede liste ikke er null og har den forventede antal
            Assert.IsNotNull(ejendommeList);
            Assert.AreEqual(10, ejendommeList.Count);
        }

        [TestMethod]
        public void TestAddEjendomme()
        {
            // Arrange: Opret et nyt Ejendomme objekt + aflæser antal af ejendomme i repositoriet
            List<Ejendomme> ejendommeList = repository.GetAll();
            int expected = ejendommeList.Count + 1;
            Ejendomme newEjendomme = new Ejendomme(28, 300000, 100, "A", 4632);

            // Act: Tilføj den nye Ejendomme til repository
            repository.AddEjendomme(newEjendomme);
            // Act: Hent listen af alle Ejendomme
            ejendommeList = repository.GetAll();
            
            // Assert: Verificer at den nye Ejendomme er tilføjet og listen er opdateret
            Assert.IsNotNull(ejendommeList);
            Assert.AreEqual(expected, ejendommeList.Count);
            Assert.IsTrue(ejendommeList.Any(e => e.Energimærke == newEjendomme.Energimærke && e.Pris == newEjendomme.Pris));
        }

        [TestMethod]
        public void TestDeleteEjendomme()
        {
            // Arrange: Definer ID'et på den Ejendomme der skal slettes
            int idToDelete = 1;
            List<Ejendomme> ejendommeList = repository.GetAll();
            int expected = ejendommeList.Count - 1;
            // Act: Slet Ejendommen fra repository
            repository.DeleteEjendomme(idToDelete);

            // Act: Hent listen af alle Ejendomme
            ejendommeList = repository.GetAll(); 
            // Assert: Verificer at Ejendommen er slettet og listen er opdateret
            Assert.IsNotNull(ejendommeList);
            Assert.AreEqual(expected, ejendommeList.Count);
            Assert.IsFalse(ejendommeList.Any(e => e.Id == idToDelete));
        }
    }
}
