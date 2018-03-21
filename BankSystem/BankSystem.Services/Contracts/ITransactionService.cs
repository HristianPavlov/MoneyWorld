using BankSystem.DTO;
using System;
using System.Collections.Generic;

namespace BankSystem.Services.Contracts
{
    interface ITransactionService
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
