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
        private readonly IExchangeRateService exchangeRateService;
        private readonly IMapper mapper;

        public TransactionService(IBankSystemContext dbContext, IExchangeRateService exchangeRateService, IMapper mapper)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.exchangeRateService = exchangeRateService ?? throw new ArgumentNullException(nameof(exchangeRateService)); ;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void MakeTransaction(MakeTransactionModel transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException("Transaction cannot be null");
            }

            if (transaction.Amount < 0)
            {
                throw new ArgumentException("Cannot send negative money.");
            }
            if (transaction.SenderBankAccountId == transaction.ReceiverBankAccountId)
            {
                throw new ArgumentException("Cannot send to same bank account");
            }

            var user = this.dbContext.Users.FirstOrDefault(x => x.UserName == transaction.UserName);

            if (user == null)
            {
                throw new ArgumentException("User does not exist.");
            }

            if (user.BankAccounts.All(a => a.Id != transaction.SenderBankAccountId))
            {
                throw new ArgumentException("Cannot send from other bank account");
            }

            var senderBankAcc = user.BankAccounts.FirstOrDefault(b => b.Id == transaction.SenderBankAccountId);

            var amountToSubtract = transaction.Amount;

            var senderRate = this.exchangeRateService.GetExchangeRate(new ExchangeRateModel()
            {
                FromCurrency = transaction.Currency,
                ToCurrency = senderBankAcc.Currency
            });

            amountToSubtract *= senderRate;


            if (amountToSubtract > senderBankAcc.Amount)
            {
                throw new ArgumentException("Cannot send more money then you have.");
            }

            senderBankAcc.Amount -= amountToSubtract;

            var receiverBankAcc =
                this.dbContext.BankAccounts.FirstOrDefault(b => b.Id == transaction.ReceiverBankAccountId);

            if (receiverBankAcc == null)
            {
                throw new ArgumentException("Cannot find receiver bank account.");
            }

            var amountToAdd = transaction.Amount;

            var receiverRate = this.exchangeRateService.GetExchangeRate(new ExchangeRateModel()
            {
                FromCurrency = transaction.Currency,
                ToCurrency = receiverBankAcc.Currency
            });

            amountToAdd *= receiverRate;

            receiverBankAcc.Amount += amountToAdd;

            var transactionToAdd = this.mapper.Map<Transaction>(transaction);

            transactionToAdd.Date = DateTime.Now;

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
