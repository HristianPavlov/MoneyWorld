using BankSystem.Common.Mapping;
using BankSystem.Models;
using BankSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTO
{
   public class BankAccountAddAspModel : IMapFrom<BankAccount>
    {
        public int Id { get; set; }


        public BankAccountType? BankAccountType { get; set; }

        public decimal Amount { get; set; }


        public Currency? Currency { get; set; }

        // [FOREIGNKEY]
        public string OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }

        public bool IsDeleted { get; set; }

    }
}
