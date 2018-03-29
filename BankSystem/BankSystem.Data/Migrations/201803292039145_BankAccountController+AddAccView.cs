namespace BankSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BankAccountControllerAddAccView : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BankAccounts", new[] { "Owner_Id" });
            RenameColumn(table: "dbo.BankAccounts", name: "Owner_Id", newName: "OwnerId");
            AlterColumn("dbo.BankAccounts", "OwnerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BankAccounts", "OwnerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.BankAccounts", new[] { "OwnerId" });
            AlterColumn("dbo.BankAccounts", "OwnerId", c => c.String(nullable: false, maxLength: 128));
            RenameColumn(table: "dbo.BankAccounts", name: "OwnerId", newName: "Owner_Id");
            CreateIndex("dbo.BankAccounts", "Owner_Id");
        }
    }
}
