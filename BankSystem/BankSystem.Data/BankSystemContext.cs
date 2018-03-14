using System.Data.Entity;
using BankSystem.Models;

namespace BankSystem.Data
{
    public class BankSystemContext : DbContext
    {
        public BankSystemContext()
            : base("BankSystem")
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}
