using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataObjects;


namespace DataAccessLayer
{
    public class CardAccessor : ICardAccessor
    {
        public List<Cards> SelectCardsByPage(int pageNum = 1)
        {
            throw new NotImplementedException();
        }
    }
}
