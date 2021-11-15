using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataObjects;
using LogicLayer;
using DataAccessInterfaces;
using DataAccessFakes;

namespace LogicLayerTests
{
    [TestClass]
    public class CardManagerTests
    {
        private ICardManager cardManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            cardManager = new CardManager(new CardAccessorFake());
        }

        [TestMethod]
        public void TestRetrieveCardByPageReturns()
        {
            const int pageNum = 1;
            const int expectedCount = 2;
            int actualCount;

            actualCount = cardManager.RetrieveCardsByPage(pageNum).Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
