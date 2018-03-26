using BankSystem.Data.Contracts;
using BankSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BankSystem.Data
{
    public class BankSystemContext : IdentityDbContext<ApplicationUser>, IBankSystemContext
    {
        public BankSystemContext()
            : base("BankSystem")
        {
        }

        public BankSystemContext(DbConnection connection)
            : base(connection, true)
        {
        }

        public IDbSet<BankAccount> BankAccounts { get; set; }

        public IDbSet<Card> Cards { get; set; }

        public IDbSet<Transaction> Transactions { get; set; }

        public IDbSet<ExchangeRate> ExchangeRates { get; set; }


        // look at the original in SocialNetwork
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<BankAccount>()
                .HasMany(b => b.SendTransactions)
                .WithRequired(t => t.Sender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BankAccount>()
                .HasMany(b => b.ReceivedTransactions)
                .WithRequired(t => t.Receiver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Contacts)
                .WithRequired(c => c.Owner)
                .WillCascadeOnDelete(false);
        }

        public static BankSystemContext Create()
        {
            return new BankSystemContext();
        }

        //RegisterConfigurations
    }
}
