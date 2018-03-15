using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BankSystem.Models.Enums;

namespace BankSystem.Models
{
    public class BankAccount
    {
        public BankAccount()
        {
            this.Cards = new HashSet<Card>();
            this.SendTransactions = new HashSet<Transaction>();
            this.ReceivedTransactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Bank account shoud have type.")]
        public BankAccountType? BankAccountType { get; set; }

        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Bank account should have currency type.")]
        public Currency? Currency { get; set; }

        [Required(ErrorMessage = "Bank account should have owner.")]
        public virtual Client Owner { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Card> Cards { get; set; }

        public virtual ICollection<Transaction> SendTransactions { get; set; }

        public virtual ICollection<Transaction> ReceivedTransactions { get; set; }

    }
}
