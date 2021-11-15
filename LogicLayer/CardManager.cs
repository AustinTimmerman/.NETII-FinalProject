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

            try
            {
                cards = _cardAccessor.SelectCardsByPage(pageNum);
            }
            catch (Exception)
            {

                throw;
            }

            return cards;
        }
    }
}
