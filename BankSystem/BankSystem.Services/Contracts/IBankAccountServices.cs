using BankSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Services.Contracts
{
    public interface IBankAccountServices
    {
        void AddBankAccount(BankAccountReadModel bankAccount);
        
        BankAccountReadModel DeleteBankAccount(string id);

    
    }
}
