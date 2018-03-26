namespace BankSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetachClientTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClientContacts", "Target_Id", "dbo.Clients");
            DropForeignKey("dbo.ClientContacts", "Owner_Id", "dbo.Clients");
            DropForeignKey("dbo.BankAccounts", "Owner_Id", "dbo.Clients");
            DropIndex("dbo.BankAccounts", new[] { "Owner_Id" });
            DropIndex("dbo.ClientContacts", new[] { "Target_Id" });
            DropIndex("dbo.ClientContacts", new[] { "Owner_Id" });
            DropColumn("dbo.BankAccounts", "Owner_Id");
            DropTable("dbo.ClientContacts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClientContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 1000),
                        Target_Id = c.Int(),
                        Owner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BankAccounts", "Owner_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ClientContacts", "Owner_Id");
            CreateIndex("dbo.ClientContacts", "Target_Id");
            CreateIndex("dbo.BankAccounts", "Owner_Id");
            AddForeignKey("dbo.BankAccounts", "Owner_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.ClientContacts", "Owner_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.ClientContacts", "Target_Id", "dbo.Clients", "Id");
        }
    }
}
