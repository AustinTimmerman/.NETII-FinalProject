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
    public class MatchManagerTests
    {
        MatchManager matchManager;

        [TestInitialize]
        public void TestSetup()
        {
            matchManager = new MatchManager(new MatchAccessorFake());
        }

        [TestMethod]
        public void TestRetrieveMatchesByPageReturnsMatches()
        {
            const int pageNum = 1;
            const int expectedCount = 2;
            int actualCount;

            actualCount = matchManager.RetrieveMatchesByPage(pageNum).Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestRetrieveMatchDecksReturnMatchDecks()
        {
            const int matchID = 999999;
            const int expectedCount = 2;
            int actualCount;

            actualCount = matchManager.RetrieveMatchDecksByMatchID(matchID).Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestRetrieveUserMatchesByUserIDReturnsMatches()
        {
            const int userID = 999999;
            const int pageNum = 1;
            const int expectedCount = 2;
            int actualCount;

            actualCount = matchManager.RetrieveUserMatchesByUserID(userID, pageNum).Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
