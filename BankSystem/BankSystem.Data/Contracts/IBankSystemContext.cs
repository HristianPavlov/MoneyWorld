using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Data.Contracts
{
    public interface IBankSystemContext
    {
         IDbSet<Client> Clients { get; set; }

         IDbSet<BankAccount> BankAccounts { get; set; }

         IDbSet<Card> Cards { get; set; }

         IDbSet<Transaction> Transactions { get; set; }

         IDbSet<ExchangeRate> ExchangeRates { get; set; }

        int SaveChanges();

    }
}
