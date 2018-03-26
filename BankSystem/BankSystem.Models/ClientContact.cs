using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class ClientContact
    {
        public int Id { get; set; }

        public string OwnerId { get; set; }

        public ApplicationUser Owner { get; set; }

        public string TargetId { get; set; }

        public ApplicationUser Target { get; set; }

        [MaxLength(1000, ErrorMessage = "A thousand chars are enough, dude!")]
        public string Description { get; set; }
    }
}
