using BankSystem.Models.Enums;

namespace BankSystem.DTO
{
    public class ExchangeRateModel
    {
        public Currency FromCurrency { get; set; }

        public Currency ToCurrency { get; set; }
    }
}
