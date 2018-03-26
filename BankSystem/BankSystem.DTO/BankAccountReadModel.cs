using BankSystem.Common.Mapping;
using BankSystem.DTO.ClientModels;
using BankSystem.Models;
using BankSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DTO
{
   public class BankAccountReadModel :   IMapFrom<BankAccount>
    {
        public int Id { get; set; }
        
                
        public BankAccountType? BankAccountType { get; set; }

        public decimal Amount { get; set; }

        
        public Currency? Currency { get; set; }

       
        public virtual ClientReadModel Owner { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<CardModel> Cards { get; set; }

        public virtual ICollection<TransactionInfoModel> SendTransactions { get; set; }

        public virtual ICollection<TransactionInfoModel> ReceivedTransactions { get; set; }
    }
}
