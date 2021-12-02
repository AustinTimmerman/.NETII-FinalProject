﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayer
{
    public interface IDeckManager
    {
        List<Deck> RetrieveDecksByPage(int pageNum = 1);
        List<DeckCard> RetrieveDeckCards(int deckID);
        List<Deck> RetrieveUserDecksByUserID(int userID, int pageNum = 1);
    }
}
