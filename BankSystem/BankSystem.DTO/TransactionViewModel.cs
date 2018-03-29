using System;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.DTO
{
    public class TransactionViewModel
    {
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
}
