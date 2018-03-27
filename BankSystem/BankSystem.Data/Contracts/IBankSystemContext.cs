using BankSystem.Models;
using System.Data.Entity;

namespace BankSystem.Data.Contracts
{
    public interface IBankSystemContext
    {
        IDbSet<BankAccount> BankAccounts { get; set; }

        IDbSet<Card> Cards { get; set; }

        IDbSet<Transaction> Transactions { get; set; }

        IDbSet<ExchangeRate> ExchangeRates { get; set; }

        IDbSet<ApplicationUser> Users { get; set; }

        int SaveChanges();

    }
}
