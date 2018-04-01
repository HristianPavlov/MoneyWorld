using BankSystem.Common.Mapping;
using BankSystem.Models;
using System.Collections.Generic;

namespace BankSystem.DTO
{
    public class UserBankAccounts : IMapFrom<ApplicationUser>
    {
        public int SelectItemId { get; set; }

        public IEnumerable<BankAccount> BankAccounts { get; set; }
    }
}