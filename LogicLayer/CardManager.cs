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

        public List<UserCard> RetrieveUserCardsByUserID(int userID, int pageNum = 1)
        {
            List<UserCard> userCards = new List<UserCard>();
            pageNumber = pageNum;
            try
            {
                userCards = _cardAccessor.SelectUserCardsByUserID(userID, pageNumber);
            }
            catch (Exception)
            {

                throw;
            }

            return userCards;
        }
    }
}
