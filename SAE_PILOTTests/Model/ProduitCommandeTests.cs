using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE_PILOT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_PILOT.Model.Tests
{
    [TestClass()]
    public class ProduitCommandeTests
    {
        [TestMethod()]
        public void ProduitCommandeTest_Prix()
        {
            ProduitCommande pc = new ProduitCommande(1, 1, 2, 2.16);
            Assert.AreEqual<double>(4.32, (double)pc.Prix, "Prix incorrect");
        }
    }
}