namespace BankSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRequiredTableProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankAccounts", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cards", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clients", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Transactions", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ExchangeRates", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExchangeRates", "IsDeleted");
            DropColumn("dbo.Transactions", "IsDeleted");
            DropColumn("dbo.Clients", "IsDeleted");
            DropColumn("dbo.Cards", "IsDeleted");
            DropColumn("dbo.BankAccounts", "IsDeleted");
        }
    }
}
