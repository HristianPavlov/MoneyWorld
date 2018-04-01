using BankSystem.Data.Contracts;
using BankSystem.DTO;
using BankSystem.Services.Contracts;
using System;
using System.Linq;

namespace BankSystem.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IBankSystemContext dbContext;

        public ExchangeRateService(IBankSystemContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public decimal GetExchangeRate(ExchangeRateModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Exchange model cannot be null.");
            }

            if (model.FromCurrency == model.ToCurrency)
            {
                return 1;
            }

            var exchange = this.dbContext.ExchangeRates
                .FirstOrDefault(r => r.FromCurrency == model.FromCurrency && r.ToCurrency == model.ToCurrency);

            if (exchange == null)
            {
                throw new ArgumentException("Cannot find exchange rate.");
            }

            return exchange.Rate;
        }
    }
}
