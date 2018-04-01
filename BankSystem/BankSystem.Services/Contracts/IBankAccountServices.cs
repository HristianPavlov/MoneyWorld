using BankSystem.DTO;
using System.Collections.Generic;

namespace BankSystem.Services.Contracts
{
    public interface IBankAccountServices
    {
        void AddBankAccount(BankAccountAddAspModel bankAccount);

        BankAccountReadModel DeleteBankAccount(string id);

        IEnumerable<BankAccountReadModel> GetAllBankAccounts();


        BankAccountReadModel GetBankAccountByID(string id);

        UserBankAccounts GetUserBankAccounts(string userName);

    }
}
