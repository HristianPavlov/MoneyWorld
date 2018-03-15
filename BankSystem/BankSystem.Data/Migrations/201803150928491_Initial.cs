namespace BankSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankAccountType = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.Int(nullable: false),
                        Owner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false, maxLength: 16),
                        Pin = c.String(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        SecretNumber = c.String(nullable: false, maxLength: 3),
                        Account_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankAccounts", t => t.Account_Id)
                .Index(t => t.Number, unique: true)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        UserName = c.String(maxLength: 30),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.ExchangeRates",
                c => new
                    {
                        FromCurrency = c.Int(nullable: false),
                        ToCurrency = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.FromCurrency, t.ToCurrency });
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Receiver_Id = c.Int(nullable: false),
                        Sender_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankAccounts", t => t.Receiver_Id)
                .ForeignKey("dbo.BankAccounts", t => t.Sender_Id)
                .Index(t => t.Receiver_Id)
                .Index(t => t.Sender_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Sender_Id", "dbo.BankAccounts");
            DropForeignKey("dbo.Transactions", "Receiver_Id", "dbo.BankAccounts");
            DropForeignKey("dbo.BankAccounts", "Owner_Id", "dbo.Clients");
            DropForeignKey("dbo.Cards", "Account_Id", "dbo.BankAccounts");
            DropIndex("dbo.Transactions", new[] { "Sender_Id" });
            DropIndex("dbo.Transactions", new[] { "Receiver_Id" });
            DropIndex("dbo.Clients", new[] { "UserName" });
            DropIndex("dbo.Cards", new[] { "Account_Id" });
            DropIndex("dbo.Cards", new[] { "Number" });
            DropIndex("dbo.BankAccounts", new[] { "Owner_Id" });
            DropTable("dbo.Transactions");
            DropTable("dbo.ExchangeRates");
            DropTable("dbo.Clients");
            DropTable("dbo.Cards");
            DropTable("dbo.BankAccounts");
        }
    }
}
