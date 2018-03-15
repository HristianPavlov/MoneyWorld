using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models
{
    public class Card
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Required(ErrorMessage = "Card should have number.")]
        [MinLength(16, ErrorMessage = "Card number should be 16 symbols long.")]
        [MaxLength(16, ErrorMessage = "Card number should be 16 symbols long.")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Card should have pin.")]
        public string Pin { get; set; }

        [Required(ErrorMessage = "Card should have expiration date.")]
        public DateTime? ExpirationDate { get; set; }

        [Required(ErrorMessage = "Card should have secret number.")]
        [MinLength(3, ErrorMessage = "Card secret number should be 3 symbols long.")]
        [MaxLength(3, ErrorMessage = "Card secret number should be 3 symbols long.")]
        public string SecretNumber { get; set; }

        [Required(ErrorMessage = "Card should have associated bank account.")]
        public virtual BankAccount Account { get; set; }

        public bool IsDeleted { get; set; }
    }
}
