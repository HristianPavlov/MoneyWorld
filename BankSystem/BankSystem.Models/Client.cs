using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models
{
    public class Client
    {
        //public Client()
        //{
        //    this.BankAccounts = new HashSet<BankAccount>();
        //    this.Contacts = new HashSet<ClientContact>();
        //}

        public int Id { get; set; }

        [Required(ErrorMessage = "Client shoud have first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Client shoud have last name.")]
        public string LastName { get; set; }

        [Index(IsUnique = true)]
        [MinLength(8, ErrorMessage = "Username should be at least 8 symbols long.")]

        [MaxLength(30, ErrorMessage = "Username should be no longer than 8 symbols.")]

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsDeleted { get; set; }

        //public virtual ICollection<BankAccount> BankAccounts { get; set; }

        //public virtual ICollection<ClientContact> Contacts { get; set; }
    }
}
