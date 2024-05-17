using System;
using Green_home.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Green_home.Tests.Model
{
    [TestClass]
    public class EjendommeTest
    {
        private Ejendomme ejendomme;

        [TestInitialize]
        public void BeforeEachTest()
        {
            //Arrange
            ejendomme = new Ejendomme();
        }

        [TestMethod()]
        [DataRow(10000, 150000000, 10, "B", 3)]
        [DataRow(999999, 87999999, 1250, "D", 909999)]
        public void Constructor_Initialization(int id, float pris, int kvm, string energimærke, int by_id)
        {

            // Act
            ejendomme = new Ejendomme(id, pris, kvm, energimærke, by_id);

            // Assert
            Assert.AreEqual(id, ejendomme.Id);
            Assert.AreEqual(pris, ejendomme.Pris);
            Assert.AreEqual(kvm, ejendomme.Kvm);
            Assert.AreEqual(energimærke, ejendomme.Energimærke);
            Assert.AreEqual(by_id, ejendomme.Post_nr);
        }
        
        [TestMethod]
        public void BeforeEachTest2()
        {
            Assert.Fail();
        } 
        
    }
 
}