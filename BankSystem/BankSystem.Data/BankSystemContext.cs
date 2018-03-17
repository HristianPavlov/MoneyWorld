﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BankSystem.Models;

namespace BankSystem.Data
{
    public class BankSystemContext : DbContext
    {
        public BankSystemContext()
            : base("BankSystem")
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<ExchangeRate> ExchangeRates { get; set; }

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
        }
    }
}