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
        [DataRow(10000, 150000000, 10, "D", 3)]
        [DataRow(999999, 87999999, 1250, "D", 909999)]
        public void Constructor_Initialization(int id, float pris, int kvm, string energimærke, int post_nr)
        {

            // Act
            ejendomme = new Ejendomme(id, pris, kvm, energimærke,post_nr );

            // Assert
            Assert.AreEqual(id, ejendomme.Id);
            Assert.AreEqual(pris, ejendomme.Pris);
            Assert.AreEqual(kvm, ejendomme.Kvm);
            Assert.AreEqual(energimærke, ejendomme.Energimærke);
            Assert.AreEqual(post_nr, ejendomme.Post_nr);
        }
        
    }
 
}