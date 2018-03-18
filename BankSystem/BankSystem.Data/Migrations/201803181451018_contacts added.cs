namespace BankSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactsadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 1000),
                        Target_Id_Id = c.Int(),
                        Owner_Id_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Target_Id_Id)
                .ForeignKey("dbo.Clients", t => t.Owner_Id_Id)
                .Index(t => t.Target_Id_Id)
                .Index(t => t.Owner_Id_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientContacts", "Owner_Id_Id", "dbo.Clients");
            DropForeignKey("dbo.ClientContacts", "Target_Id_Id", "dbo.Clients");
            DropIndex("dbo.ClientContacts", new[] { "Owner_Id_Id" });
            DropIndex("dbo.ClientContacts", new[] { "Target_Id_Id" });
            DropTable("dbo.ClientContacts");
        }
    }
}
