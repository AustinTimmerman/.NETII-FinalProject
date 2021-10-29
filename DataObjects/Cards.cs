using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Cards
    {
        public string CardID {get; set;}
        public string ImageID { get; set; }
        public string CardDescription { get; set; }
        public string CardColorID { get; set; }
        public int CardConvertedManaCost { get; set; }
        public string CardTypeID { get; set; }
        public string CardRarityID { get; set; }
        public bool OwnedCard { get; set; }
        public bool Wishlisted { get; set; }
    }
}
