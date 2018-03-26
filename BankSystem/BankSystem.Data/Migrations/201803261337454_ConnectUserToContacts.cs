namespace BankSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectUserToContacts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.String(nullable: false, maxLength: 128),
                        TargetId = c.String(maxLength: 128),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.TargetId)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerId)
                .Index(t => t.OwnerId)
                .Index(t => t.TargetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientContacts", "OwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClientContacts", "TargetId", "dbo.AspNetUsers");
            DropIndex("dbo.ClientContacts", new[] { "TargetId" });
            DropIndex("dbo.ClientContacts", new[] { "OwnerId" });
            DropTable("dbo.ClientContacts");
        }
    }
}
