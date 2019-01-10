using Logic;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using Moq;
using Interface_Logic_DAL;
using Factory2;

namespace Logic.Tests
{
    [TestClass()]
    public class ActiviteitLogicTests
    {
        //Unit tests
        private Mock<MemoryFactory> _memoryFactoryMock;
        private Activiteit _activiteit;

        [TestInitialize]
        public void SetUp()
        {
            _memoryFactoryMock = new Mock<MemoryFactory>();
            _activiteit = new Activiteit(_memoryFactoryMock.Object);
        }

        [TestMethod()]
        public void ToonOverzichtLineTest()
        {
            List<ActiviteitInfo> overzichtLine = new List<ActiviteitInfo>();
            ActiviteitInfo activiteit = new ActiviteitInfo(2, 2);
            ActiviteitInfo activiteit2 = new ActiviteitInfo(6, 3);
            overzichtLine.Add(activiteit);
            overzichtLine.Add(activiteit2);
            _memoryFactoryMock.Setup(m => m.GegevensOverzichtOphalenLine(6)).Returns(overzichtLine);
            var result = _activiteit.ToonOverzichtLine(6);

            Assert.AreEqual(2, overzichtLine.Count);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
        }

        [TestMethod()]
        public void ToonOverzichtTijdBarTest()
        {
            //Setup om andere dal te gebruiken
            List<double> overzichtTijdBar = new List<double>();
            overzichtTijdBar.Add(60);
            overzichtTijdBar.Add(120);
            _memoryFactoryMock.Setup(m => m.GegevensOverzichtOphalenTijdBar(6)).Returns(overzichtTijdBar);
            var result = _activiteit.ToonOverzichtTijdBar(6);

            Assert.AreEqual(2, overzichtTijdBar.Count);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
        }

        [TestMethod()]
        public void ToonOverzichtAfstandBarTest()
        {
            List<double> overzichtAfstandBar = new List<double>();
            overzichtAfstandBar.Add(1000);
            overzichtAfstandBar.Add(2000);
            _memoryFactoryMock.Setup(m => m.GegevensOverzichtOphalenAfstandBar(6)).Returns(overzichtAfstandBar);
            var result = _activiteit.ToonOverzichtAfstandBar(6);

            Assert.AreEqual(2, overzichtAfstandBar.Count);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
        }

        //Intergration test TijdBar
    }
}