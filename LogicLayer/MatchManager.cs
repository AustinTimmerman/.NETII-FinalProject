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
    public class MatchManager : IMatchManager
    {
        IMatchAccessor _matchAccessor;

        public MatchManager()
        {
            _matchAccessor = new MatchAccessor();
        }

        public MatchManager(IMatchAccessor matchAccessor)
        {
            _matchAccessor = matchAccessor;
        }

        public List<MatchDeck> RetrieveMatchDecksByMatchID(int matchID)
        {
            List<MatchDeck> matchDecks = new List<MatchDeck>();

            try
            {
                matchDecks = _matchAccessor.SelectMatchDecksByMatchID(matchID);
            }
            catch (Exception)
            {

                throw;
            }

            return matchDecks;
        }

        public List<Match> RetrieveMatchesByPage(int pageNum = 1)
        {
            List<Match> matches = new List<Match>();

            try
            {
                matches = _matchAccessor.SelectMatchesByPage(pageNum);
            }
            catch (Exception)
            {
                throw;
            }

            return matches;

        }
    }
}
