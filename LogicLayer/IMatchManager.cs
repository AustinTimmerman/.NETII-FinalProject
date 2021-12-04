using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayer
{
    public interface IMatchManager
    {   
        List<MatchDeck> RetrieveMatchDecksByMatchID(int matchID);
        List<Match> RetrieveMatchesByPage(int pageNum = 1);
        List<Match> RetrieveUserMatchesByUserID(int userID, int pageNum = 1);
    }
}
