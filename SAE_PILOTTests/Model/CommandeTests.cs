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
    public class CommandeTests
    {
        [TestMethod()]
        public void CommandeTest_Employe()
        {
            Commande commande = new Commande(1, 1, 1, 1, DateTime.Today, DateTime.Today);
            Assert.AreEqual("Poupeau Baptiste", commande.NomCompletEmploye, "Nom incorrect");
        }
        [TestMethod()]
        public void CommandeTest_Transport()
        {
            Commande commande = new Commande(1, 1, 1, 1, DateTime.Today, DateTime.Today);
            Assert.AreEqual("UPS", commande.NomTransport, "Nom incorrect");
        }
    }
}