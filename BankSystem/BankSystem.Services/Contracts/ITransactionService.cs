using BankSystem.DTO;
using BankSystem.DTO.ClientModels;
using System;
using System.Collections.Generic;

namespace BankSystem.Services.Contracts
{
    public interface ITransactionService
    {
        void AddTransaction(TransactionAddModel transaction);

        IEnumerable<TransactionInfoModel> GetAllClientTransactions(ClientModel client);

        IEnumerable<TransactionInfoModel> GetBankAccountTransactions(BankAccountModel bankAccount);

        IEnumerable<TransactionInfoModel> GetClientTransactionsFromDateToDate
            (ClientModel client, DateTime startDate, DateTime endDate);

        IEnumerable<TransactionInfoModel> GetBankAccountTransactionsFromDateToDate
            (BankAccountModel bankAccount, DateTime startDate, DateTime endDate);

    }
}
