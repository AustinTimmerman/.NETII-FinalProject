using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using DataAccessFakes;
using DataAccessInterfaces;
using DataObjects;
using System.Collections.Generic;

namespace LogicLayerTests
{
    [TestClass]
    public class DeckManagerTests
    {
        DeckManager deckManager;
        [TestInitialize]
        public void TestSetup()
        {
            deckManager = new DeckManager(new DeckAccessorFake());
        }

        [TestMethod]
        public void TestRetrieveDecksByPageReturnsDecks()
        {
            const int pageNum = 1;
            const int expectedCount = 2;
            int actualCount;

            actualCount = deckManager.RetrieveDecksByPage(pageNum).Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestRetrieveDeckCardsByDeckIDReturnsDeckCards()
        {
            const int deckID = 999999;
            const int expectedCount = 6;
            int actualCount;

            actualCount = deckManager.RetrieveDeckCards(deckID).Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
