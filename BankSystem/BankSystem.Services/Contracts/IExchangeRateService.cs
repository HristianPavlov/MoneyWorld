using BankSystem.DTO;

namespace BankSystem.Services.Contracts
{
    public interface IExchangeRateService
    {
        decimal GetExchangeRate(ExchangeRateModel model);
    }
}
