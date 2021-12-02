using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessInterfaces
{
    public interface IDeckAccessor
    {
        List<Deck> SelectDecksByPage(int pageNum);
        List<DeckCard> SelectDeckCards(int deckID);
        List<Deck> SelectUserDecksByUserID(int userID, int pageNum);
    }
}
