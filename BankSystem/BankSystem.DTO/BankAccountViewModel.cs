using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTO
{
    public class BankAccountViewModel
    {
        public int BankAccountID { get; set; }

        public IEnumerable<BankAccountReadModel> BankAccounts { get; set; }
    }
}
