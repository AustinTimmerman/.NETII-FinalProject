using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataObjects;

namespace DataAccessLayer
{
    public class MatchAccessor : IMatchAccessor
    {
        public List<MatchDeck> SelectMatchDecksByMatchID(int matchID)
        {
            List<MatchDeck> matchDecks = new List<MatchDeck>();
            var conn = DBConnection.GetConnection();
            string commandText = @"sp_select_match_decks_by_matchID";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MatchID", SqlDbType.Int);
            cmd.Parameters["@MatchID"].Value = matchID;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        matchDecks.Add(new MatchDeck()
                        {
                            MatchID = matchID,
                            DeckID = reader.GetInt32(0),
                            DeckName = reader.GetString(1),
                            Winner = reader.GetBoolean(2)
                        });
                    }
                }
                //else
                //{
                //    throw new ApplicationException("There are no decks!");
                //}
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
            var conn = DBConnection.GetConnection();
            string commandText = @"sp_select_matches_by_page";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageNumber", SqlDbType.Int);
            cmd.Parameters["@PageNumber"].Value = pageNum;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        matches.Add(new Match()
                        {
                            MatchID = reader.GetInt32(0),
                            MatchName = reader.GetString(1),
                            UserID = reader.GetInt32(2),
                            IsPublic = reader.GetBoolean(3)
                        });
                    }
                }
                //else
                //{
                //    throw new ApplicationException("There are no matches!");
                //}
            }
            catch (Exception)
            {
                throw;
            }

            return matches;
        }

        public List<Match> SelectUserMatchesByUserID(int userID, int pageNum)
        {
            List<Match> userMatches = new List<Match>();
            var conn = DBConnection.GetConnection();
            string commandText = @"sp_select_user_matches_by_userID";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters.Add("@PageNumber", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = userID;
            cmd.Parameters["@PageNumber"].Value = pageNum;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userMatches.Add(new Match()
                        {
                            MatchID = reader.GetInt32(0),
                            MatchName = reader.GetString(1),
                            UserID = userID,
                            IsPublic = reader.GetBoolean(3)
                        });
                    }
                }
                //else
                //{
                //    throw new ApplicationException("There are no user matches!");
                //}
            }
            catch (Exception)
            {
                throw;
            }

            return userMatches;
        }
    }
}
