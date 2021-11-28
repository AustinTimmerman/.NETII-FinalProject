using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessInterfaces;

namespace DataAccessFakes
{
    public class CardAccessorFake : ICardAccessor
    {
        private List<Cards> fakeCards = new List<Cards>();
        public CardAccessorFake()
        {
            fakeCards.Add(new Cards()
            {
                CardID = 100000,
                CardName = "Toxrill, the Corrosive",
                ImageID = 100000,
                CardDescription = "At the beginning of each end step, put a slime counter on each creature you don't control.",
                CardColorID = "Multi-Colored",
                CardConvertedManaCost = 7,
                CardRarityID = "Mythic Rare",
                CardTypeID = "Legendary Creature",
                HasSecondaryCard = false,
                OwnedCard = true,
                Wishlisted = false
            });
            fakeCards.Add(new Cards()
            {
                CardID = 100001,
                CardName = "Runo Stormkirk",
                ImageID = 100001,
                CardDescription = "When Runo Stormkirk enters the battlefield, put up to one target creature card from your graveyard on top of your library",
                CardColorID = "Multi-Colored",
                CardConvertedManaCost = 3,
                CardRarityID = "Mythic Rare",
                CardTypeID = "Legendary Creature",
                HasSecondaryCard = false,
                OwnedCard = true,
                Wishlisted = false
            });
            fakeCards.Add(new Cards()
            {
                CardID = 100003,
                CardName = "Shipwreck Marsh",
                ImageID = 100003,
                CardDescription = "Shipwreck Marsh enters the battlefield tapped unless you control two or more other lands.",
                CardColorID = "Colorless",
                CardConvertedManaCost = 0,
                CardRarityID = "Rare",
                CardTypeID = "Land",
                HasSecondaryCard = false,
                OwnedCard = false,
                Wishlisted = true
            });
            fakeCards.Add(new Cards()
            {
                CardID = 100004,
                CardName = "Curse of Leeches",
                ImageID = 100004,
                CardDescription = "As this permanent transforms into Curse of leeches, attach it to a player.",
                CardColorID = "Black",
                CardConvertedManaCost = 3,
                CardRarityID = "Rare",
                CardTypeID = "Enchantment",
                HasSecondaryCard = true,
                CardSecondaryName = "Leeching Lurker",
                SecondaryImageID = 100005,
                CardSecondaryDescription = "Nightbound",
                CardSecondaryColorID = "Black",
                CardSecondaryConvertedManaCost = 0,
                CardSecondaryRarityID = "Rare",
                CardSecondaryTypeID = "Creature",
                OwnedCard = true,
                Wishlisted = false
            });


        }

        public List<Cards> SelectCardsByPage(int pageNum)
        {
            List<Cards> cards = new List<Cards>();
            int index = (pageNum - 1) * 2;

            try
            {
                for(int i = 0; i < 2; i++)
                {
                    if(index > fakeCards.Count() - 1) 
                    {
                        return cards;
                    }
                    cards.Add(fakeCards[index]);
                    index++;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return cards;
        }

        public Cards SelectCardByCardID(int cardID)
        {
            for (int i = 0; i < fakeCards.Count; i++)
            {
                if (cardID == fakeCards[i].CardID)
                {
                    return fakeCards[i];
                }
            }
            throw new ApplicationException();
        }
    }
}
