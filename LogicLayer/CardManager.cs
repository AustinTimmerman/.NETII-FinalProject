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
    public class CardManager : ICardManager
    {
        private ICardAccessor _cardAccessor = null;
        private int pageNumber;

        public CardManager()
        {
            _cardAccessor = new CardAccessor();
        }

        public CardManager(ICardAccessor cardAccessor)
        {
            _cardAccessor = cardAccessor;
        }

        public List<Cards> RetrieveCardsByPage(int pageNum = 1)
        {
            List<Cards> cards = new List<Cards>();
            pageNumber = pageNum;

            try
            {
                cards = _cardAccessor.SelectCardsByPage(pageNumber);
            }
            catch (Exception)
            {

                throw;
            }

            return cards;
        }

        public List<Cards> RetrieveWishlistedCardsByUserID(int userID)
        {
            List<Cards> cards = new List<Cards>();

            try
            {
                cards = _cardAccessor.SelectWishlistedCardsByUserID(userID);
            }
            catch (Exception)
            {

                throw;
            }

            return cards;
        }
    }
}
