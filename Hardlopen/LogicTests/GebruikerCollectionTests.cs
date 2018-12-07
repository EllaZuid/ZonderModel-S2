using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Tests
{
    [TestClass()]
    public class GebruikerCollectionTests
    {
        private readonly Gebruiker _gebruikerGoed = new Gebruiker(6, "Ella", "Test");
        private readonly Gebruiker _gebruikerNull = new Gebruiker();

        [TestMethod()]
        public void InloggenTestIdGebruikerGoed()
        {
            Assert.IsNotNull(_gebruikerGoed.Id);
        }

        [TestMethod()]
        public void InloggenTestIdGebruikerFout()
        {
            Assert.IsNotNull(_gebruikerNull.Id);
        }

        [TestMethod()]
        public void InloggenTestNaamGebruikerGoed()
        {
            Assert.IsNotNull(_gebruikerGoed.Naam);
        }

        [TestMethod()]
        public void InloggenTestNaamGebruikerFout()
        {
            Assert.IsNull(_gebruikerNull.Naam);
        }

        [TestMethod()]
        public void InloggenTestWachtwoordGebruikerGoed()
        {
            Assert.IsNotNull(_gebruikerGoed.Wachtwoord);
        }

        [TestMethod()]
        public void InloggenTestWachtwoordGebruikerFout()
        {
            Assert.IsNull(_gebruikerNull.Wachtwoord);
        }
    }
}