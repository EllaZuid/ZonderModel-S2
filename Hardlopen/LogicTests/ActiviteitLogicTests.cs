using Logic;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using Model;
using Moq;

namespace Logic.Tests
{
    [TestClass()]
    public class ActiviteitLogicTests
    {
        //Intergration tests
        private Mock<ActiviteitDal> _activiteitDalMock;
        private ActiviteitLogic _activiteitLogic;

        [TestInitialize]
        public void SetUp()
        {
            _activiteitDalMock = new Mock<ActiviteitDal>();
            _activiteitLogic = new ActiviteitLogic(_activiteitDalMock.Object);
        }

        [TestMethod()]
        public void ToonOverzichtLineTest()
        {
            List<Activiteit> overzichtLine = new List<Activiteit>();
            Activiteit activiteit = new Activiteit(2, 2);
            Activiteit activiteit2 = new Activiteit(3, 3);
            overzichtLine.Add(activiteit);
            overzichtLine.Add(activiteit2);
            _activiteitDalMock.Setup(m => m.GegevensOverzichtOphalenLine(6)).Returns(overzichtLine);
            var result = _activiteitLogic.ToonOverzichtLine(6);

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(1, result[1]);
        }

        [TestMethod()]
        public void ToonOverzichtTijdBarTest()
        {
            //Setup om andere dal te gebruiken
            List<double> overzichtTijdBar = new List<double>();
            overzichtTijdBar.Add(60);
            overzichtTijdBar.Add(120);
            _activiteitDalMock.Setup(m => m.GegevensOverzichtOphalenTijdBar(6)).Returns(overzichtTijdBar);
            var result = _activiteitLogic.ToonOverzichtTijdBar(6);

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
        }

        [TestMethod()]
        public void ToonOverzichtAfstandBarTest()
        {
            List<double> overzichtAfstandBar = new List<double>();
            overzichtAfstandBar.Add(1000);
            overzichtAfstandBar.Add(2000);
            _activiteitDalMock.Setup(m => m.GegevensOverzichtOphalenAfstandBar(6)).Returns(overzichtAfstandBar);
            var result = _activiteitLogic.ToonOverzichtAfstandBar(6);

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
        }

        //Unit test
        [TestMethod()]
        public void GegevensInvullenTest()
        {
            Activiteit activiteit = new Activiteit(10, 6);
            ActiviteitLogic activiteitLogic = new ActiviteitLogic();
            activiteitLogic.GegevensInvullen(activiteit, 6); //Error met naar Dal laag
            Assert.Equals(activiteit.Tijd, 10000);
            Assert.Equals(activiteit.Afstand, 360);
        }
    }
}