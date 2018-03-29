using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankSystem.Data.Contracts;
using BankSystem.DTO;
using BankSystem.DTO.ClientModels;
using BankSystem.Models;
using BankSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSystem.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IBankSystemContext dbContext;
        private readonly IMapper mapper;

        public TransactionService(IBankSystemContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void AddTransaction(TransactionAddModel transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException();
            }

            var transactionToAdd = this.mapper.Map<Transaction>(transaction);

            this.dbContext.Transactions.Add(transactionToAdd);

            this.dbContext.SaveChanges();
        }

        public IEnumerable<TransactionInfoModel> GetTransactions(ClientModel client)
        {
            if (client == null)
            {
                throw new ArgumentNullException();
            }

            var result = this.dbContext.Transactions
                .Where(t => t.Sender.Owner.UserName == client.UserName || t.Receiver.Owner.UserName == client.UserName)
                .ProjectTo<TransactionInfoModel>();

            return result;
        }

        public IEnumerable<TransactionInfoModel> GetClientTransactionsFromDateToDate
            (TransactionViewModel transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException();
            }

            //var result = this.dbContext.Transactions
            //    .Where(t => (t.Sender.Owner.UserName == transaction.UserName || t.Sender.Owner.UserName == transaction.UserName) &&
            //               (t.Date >= transaction.StartDate && t.Date <= transaction.EndDate))
            //    .ProjectTo<TransactionInfoModel>();


            var result = this.dbContext.Transactions
                .Where(t => t.Sender.Owner.UserName == transaction.UserName ||
                            t.Receiver.Owner.UserName == transaction.UserName)
                .Where(t => t.Date >= transaction.StartDate)
                .Where(t => t.Date <= transaction.EndDate)
                .ProjectTo<TransactionInfoModel>();

            return result;
        }

        public IEnumerable<TransactionInfoModel> GetBankAccountTransactions(BankAccountModel bankAccount)
        {
            if (bankAccount == null)
            {
                throw new ArgumentNullException();
            }

            var result = this.dbContext.Transactions
                .Where(t => t.Sender.Id == bankAccount.Id || t.Receiver.Id == bankAccount.Id)
                .ProjectTo<TransactionInfoModel>();

            return result;
        }

        public IEnumerable<TransactionInfoModel> GetBankAccountTransactionsFromDateToDate
            (BankAccountModel bankAccount, DateTime startDate, DateTime endDate)
        {
            if (bankAccount == null)
            {
                throw new ArgumentNullException();
            }

            var result = this.dbContext.Transactions
                .Where(t => (t.Sender.Id == bankAccount.Id || t.Receiver.Id == bankAccount.Id) &&
                            (t.Date >= startDate && t.Date <= endDate))
                .ProjectTo<TransactionInfoModel>();

            return result;
        }
    }
}
