using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayer;
using DataAccessInterfaces;
using DataAccessFakes;

namespace LogicLayer
{
    public class DeckManager : IDeckManager
    {
        IDeckAccessor _deckAccessor;

        public DeckManager()
        {
            _deckAccessor = new DeckAccessor();
        }

        public DeckManager(IDeckAccessor deckAccessor)
        {
            _deckAccessor = deckAccessor;
        }

        public List<Cards> RetrieveDeckCards(int deckID)
        {
            List<Cards> deckCards = new List<Cards>();

            try
            {
                deckCards = _deckAccessor.SelectDeckCards(deckID);
            }
            catch (Exception)
            {

                throw;
            }

            return deckCards;
        }

        public List<Deck> RetrieveDecksByPage(int pageNum = 1)
        {
            List<Deck> decks = new List<Deck>();
            try
            {
                decks = _deckAccessor.SelectDecksByPage(pageNum);
            }
            catch (Exception)
            {
                throw;
            }

            return decks;
        }
    }
}
