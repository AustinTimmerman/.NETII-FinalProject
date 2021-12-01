﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessInterfaces;

namespace DataAccessFakes
{
    public class MatchAccessorFake : IMatchAccessor
    {
        private List<Match> fakeMatches = new List<Match>();
        private List<MatchDeck> fakeMatchDecks = new List<MatchDeck>();
        private DeckAccessorFake deckAccessor = new DeckAccessorFake();

        public MatchAccessorFake()
        {
            fakeMatches.Add(new Match()
            {
                MatchID = 999999,
                MatchName = "Match 1",
                UserID = 999999,
                IsPublic = true
            });
            fakeMatches.Add(new Match()
            {
                MatchID = 999998,
                MatchName = "Match 2",
                UserID = 999999,
                IsPublic = true
            });
            fakeMatchDecks.Add(new MatchDeck()
            {
                MatchID = 999999,
                DeckID = 999999,
                DeckName = deckAccessor.SelectDeckByDeckID(999999).DeckName,
                Winner = false
            });
            fakeMatchDecks.Add(new MatchDeck()
            {
                MatchID = 999999,
                DeckID = 999998,
                DeckName = deckAccessor.SelectDeckByDeckID(999998).DeckName,
                Winner = true
            });
            fakeMatchDecks.Add(new MatchDeck()
            {
                MatchID = 999998,
                DeckID = 999997,
                DeckName = deckAccessor.SelectDeckByDeckID(999997).DeckName,
                Winner = false
            });
            fakeMatchDecks.Add(new MatchDeck()
            {
                MatchID = 999998,
                DeckID = 999999,
                DeckName = deckAccessor.SelectDeckByDeckID(999999).DeckName,
                Winner = true
            });
        }

        public List<MatchDeck> SelectMatchDecksByMatchID(int matchID)
        {
            List<MatchDeck> matchDecks = new List<MatchDeck>();

            try
            {
                for (int i = 0; i < fakeMatchDecks.Count; i++)
                {
                    if (fakeMatchDecks[i].MatchID == matchID)
                    {
                        //deckCards.Add(fakeDeckCards[i]);

                        matchDecks.Add(fakeMatchDecks[i]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return matchDecks;
        }

        public List<Match> SelectMatchesByPage(int pageNum)
        {
            List<Match> matches = new List<Match>();
            int index = (pageNum - 1) * 2;

            try
            {
                for (int i = 0; i < 2; i++)
                {
                    if (index > fakeMatches.Count() - 1)
                    {
                        return matches;
                    }
                    if (fakeMatches[index].IsPublic == true)
                    {
                        matches.Add(fakeMatches[index]);
                    }
                    index++;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return matches;
        }
    }
}