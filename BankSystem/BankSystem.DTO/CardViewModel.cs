using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTO
{
    public class CardViewModel
    {
        public int CardID { get; set; }

        public IEnumerable<CardModel> Cards { get; set; }
    }
}
