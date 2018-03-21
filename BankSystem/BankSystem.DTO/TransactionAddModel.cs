using BankSystem.Common.Mapping;
using BankSystem.Models;
using BankSystem.Models.Enums;
using System;

namespace BankSystem.DTO
{
    public class TransactionAddModel : IMapFrom<Transaction>
    {
        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public decimal Amount { get; set; }

        public Currency Currency { get; set; }

        public DateTime Date { get; set; }
    }
}
