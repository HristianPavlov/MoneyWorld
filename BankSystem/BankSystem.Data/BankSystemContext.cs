using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BankSystem.Data.Contracts;
using BankSystem.Models;

namespace BankSystem.Data
{
    public class BankSystemContext : DbContext, IBankSystemContext
    {
        public BankSystemContext()
            : base("BankSystem")
        {
        }

        public BankSystemContext(DbConnection connection)
            : base(connection, true)
        {
        }
        public IDbSet<Client> Clients { get; set; }

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

            modelBuilder.Entity<Client>()
                .HasMany(b => b.Contacts)
                .WithRequired(t => t.Owner_Id)
                .WillCascadeOnDelete(false);
        }

        //RegisterConfigurations
    }
}
