using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BankSystem.Models.Enums;

namespace BankSystem.Models
{
    public class ExchangeRate
    {
        [Key, Column(Order = 0)]
        [Required(ErrorMessage = "Exchange rate should have from currency.")]
        public Currency FromCurrency { get; set; }

        [Key, Column(Order = 1)]
        [Required(ErrorMessage = "Exchange rate should have to currency.")]
        public Currency ToCurrency { get; set; }

        [Required(ErrorMessage = "Exchange rate should have rate.")]
        public decimal Rate { get; set; }
    }
}
