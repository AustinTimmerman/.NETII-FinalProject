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
    public class DeckAccessor : IDeckAccessor
    {
        public List<Cards> SelectDeckCards(int deckID)
        {
            List<Cards> deckCards = new List<Cards>();
            var conn = DBConnection.GetConnection();
            string commandText = @"sp_select_deck_cards_by_deckID";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DeckID", SqlDbType.Int);
            cmd.Parameters["@DeckID"].Value = deckID;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        deckCards.Add(new Cards()
                        {
                            CardID = reader.GetInt32(0),
                            CardName = reader.GetString(1),
                            ImageID = reader.GetInt32(2),
                            CardDescription = reader.GetString(3),
                            CardColorID = reader.GetString(4),
                            CardConvertedManaCost = reader.GetInt32(5),
                            CardTypeID = reader.GetString(6),
                            CardRarityID = reader.GetString(7),
                            HasSecondaryCard = reader.GetBoolean(8),
                            CardSecondaryName = reader.IsDBNull(9) ? null : reader.GetString(9),
                            SecondaryImageID = reader.IsDBNull(10) ? -1 : reader.GetInt32(10),
                            CardSecondaryDescription = reader.IsDBNull(11) ? null : reader.GetString(11),
                            CardSecondaryColorID = reader.IsDBNull(12) ? null : reader.GetString(12),
                            CardSecondaryConvertedManaCost = reader.IsDBNull(13) ? -1 : reader.GetInt32(13),
                            CardSecondaryTypeID = reader.IsDBNull(14) ? null : reader.GetString(14),
                            CardSecondaryRarityID = reader.IsDBNull(15) ? null : reader.GetString(15)
                        });
                    }
                }
                else
                {
                    throw new ApplicationException("There are no cards!");
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
            List<Deck> decks = new List<Deck>();
            var conn = DBConnection.GetConnection();
            string commandText = @"sp_select_decks_by_page";
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
                        decks.Add(new Deck()
                        {
                            DeckID = reader.GetInt32(0),
                            DeckName = reader.GetString(1),
                            UserID = reader.GetInt32(2),
                            IsPublic = reader.GetBoolean(3)
                        });
                    }
                }
                else
                {
                    throw new ApplicationException("There are no decks!");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return decks;
        }
    }
}
