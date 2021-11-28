using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessInterfaces;

namespace DataAccessFakes
{
    public class DeckAccessorFake : IDeckAccessor
    {
        private List<Deck> fakeDecks = new List<Deck>();
        private List<DeckCard> fakeDeckCards = new List<DeckCard>();

        public DeckAccessorFake()
        {
            fakeDecks.Add(new Deck()
            {
                DeckID = 999999,
                DeckName = "Green Deck",
                UserID = 999999,
                IsPublic = true
            });
            fakeDecks.Add(new Deck()
            {
                DeckID = 999998,
                DeckName = "Black Deck",
                UserID = 999999,
                IsPublic = true
            });
            fakeDecks.Add(new Deck()
            {
                DeckID = 999997,
                DeckName = "Blue Deck",
                UserID = 999998,
                IsPublic = false
            });
            fakeDecks.Add(new Deck()
            {
                DeckID = 999996,
                DeckName = "Red Deck",
                UserID = 999999,
                IsPublic = false
            });
            fakeDeckCards.Add(new DeckCard()
            {
                DeckID = 999999,
                CardID = 100000
            });
            fakeDeckCards.Add(new DeckCard()
            {
                DeckID = 999999,
                CardID = 100001
            });
            fakeDeckCards.Add(new DeckCard()
            {
                DeckID = 999999,
                CardID = 100000
            });
            fakeDeckCards.Add(new DeckCard()
            {
                DeckID = 999999,
                CardID = 100001
            });
            fakeDeckCards.Add(new DeckCard()
            {
                DeckID = 999999,
                CardID = 100000
            });
            fakeDeckCards.Add(new DeckCard()
            {
                DeckID = 999999,
                CardID = 100001
            });

            fakeDeckCards.Add(new DeckCard()
            {
                DeckID = 999998,
                CardID = 100000
            });
            fakeDeckCards.Add(new DeckCard()
            {
                DeckID = 999998,
                CardID = 100000
            });
        }

        public List<Cards> SelectDeckCards(int deckID)
        {
            List<Cards> deckCards = new List<Cards>();
            CardAccessorFake cardAccessor = new CardAccessorFake();

            try
            {
                for(int i = 0; i < fakeDeckCards.Count; i++)
                {
                    if(fakeDeckCards[i].DeckID == deckID)
                    {
                        //deckCards.Add(fakeDeckCards[i]);
                        deckCards.Add(cardAccessor.SelectCardByCardID(fakeDeckCards[i].CardID));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return deckCards;
        }

        public List<Deck> SelectDecksByPage(int pageNum)
        {
            List<Deck> cards = new List<Deck>();
            int index = (pageNum - 1) * 2;

            try
            {
                for (int i = 0; i < 2; i++)
                {
                    if (index > fakeDecks.Count() - 1)
                    {
                        return cards;
                    }
                    if(fakeDecks[index].IsPublic == true)
                    {
                        cards.Add(fakeDecks[index]);
                    }
                    index++;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return cards;
        }
    }
}
