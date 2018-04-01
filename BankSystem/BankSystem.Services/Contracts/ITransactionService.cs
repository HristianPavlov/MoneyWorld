using BankSystem.DTO;
using BankSystem.DTO.ClientModels;
using System.Collections.Generic;

namespace BankSystem.Services.Contracts
{
    public interface ITransactionService
    {
        void MakeTransaction(MakeTransactionModel transaction);

        IEnumerable<TransactionInfoModel> GetTransactions(ClientModel transaction);

        IEnumerable<TransactionInfoModel> GetClientTransactionsFromDateToDate(TransactionViewModel transaction);
    }
}
