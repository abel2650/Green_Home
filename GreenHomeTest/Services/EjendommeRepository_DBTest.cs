using Green_home.Services;
using Microsoft.Data.SqlClient;
using Green_home.Model;
using Moq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Ejendomme = Green_home.Model.Ejendomme;

namespace GreenHomeTest.Services{

[TestClass]

    public class EjendommeRepository_DBTest
    {
        private Mock<SqlConnection> mockConnection;
        private Mock<SqlCommand> mockCommand;
        private Mock<SqlDataReader> mockReader;
        private Mock<SqlParameterCollection> mockParameters;

        private EjendommeRepository_DB repository;

        [TestInitialize]
        public void Setup()
        {
            // Setup mocks
            SqlConnection connection = new SqlConnection(Secret.ConnectionString);
            // Create instance of repository and inject mock connection
            repository = new EjendommeRepository_DB();
            
        }

        [TestMethod]
        public void TestGetAll_EmptyList()
        {
            
            List<Ejendomme> ejendommeList = repository.GetAll();

            // Assert
            Assert.IsNotNull(ejendommeList);
            Assert.AreEqual(2, ejendommeList.Count);
        }
    }
}



