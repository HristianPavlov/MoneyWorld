using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        private ICollection<BankAccount> bankAccounts;
        private ICollection<ClientContact> contacts;

        public ApplicationUser()
        {
            this.bankAccounts = new HashSet<BankAccount>();
            this.contacts = new HashSet<ClientContact>();
        }

        [Required(ErrorMessage = "Client shoud have first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Client shoud have last name.")]
        public string LastName { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<BankAccount> BankAccounts
        {
            get => this.bankAccounts;
            set => this.bankAccounts = value;
        }

        public virtual ICollection<ClientContact> Contacts
        {
            get => this.contacts;
            set => this.contacts = value;
        }
        

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
