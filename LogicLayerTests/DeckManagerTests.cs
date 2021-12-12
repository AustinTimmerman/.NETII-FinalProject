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

        [TestMethod]
        public void TestRetrieveUserDecksByUserIDReturnsDecks()
        {
            const int userID = 999999;
            const int expectedCount = 3;
            const int pageNum = 1;
            int actualCount;

            actualCount = deckManager.RetrieveUserDecksByUserID(userID, pageNum).Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestInsertDeckReturnsTrue()
        {
            const string deckName = "New Deck";
            const int userID = 999999;
            const bool isPublic = true;
            const bool expectedResult = true;
            bool actualResult;

            actualResult = deckManager.CreateDeck(deckName, userID, isPublic);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestUpdateDeckReturnsTrue()
        {
            Deck oldDeck = new Deck()
            {
                DeckID = 999999,
                DeckName = "Deck Time",
                UserID = 999999,
                IsPublic = false
            };
            Deck newDeck = new Deck()
            {
                DeckID = 999999,
                DeckName = "Not Deck Time",
                UserID = 999999,
                IsPublic = true
            };
            const bool expectedResult = true;
            bool actualResult;

            actualResult = deckManager.EditDeck(oldDeck, newDeck);

            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod]
        public void TestUpdateDeckReturnsFalse()
        {
            Deck oldDeck = new Deck()
            {
                DeckID = 9999999,
                DeckName = "Deck Time",
                UserID = 999999,
                IsPublic = false
            };
            Deck newDeck = new Deck()
            {
                DeckID = 999999,
                DeckName = "Not Deck Time",
                UserID = 999999,
                IsPublic = true
            };
            const bool expectedResult = false;
            bool actualResult;

            actualResult = deckManager.EditDeck(oldDeck, newDeck);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestDeleteDeckReturnsTrue()
        {
            Deck deck = new Deck()
            {
                DeckID = 999999,
                DeckName = "Green Deck",
                UserID = 999999,
                IsPublic = true
            };
            const bool expectedResult = true;
            bool actualResult;

            actualResult = deckManager.RemoveDeck(deck);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestDeleteDeckReturnsFalse()
        {
            Deck deck = new Deck()
            {
                DeckID = 9999999,
                DeckName = "Green Deck",
                UserID = 999999,
                IsPublic = true
            };
            const bool expectedResult = false;
            bool actualResult;

            actualResult = deckManager.RemoveDeck(deck);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
