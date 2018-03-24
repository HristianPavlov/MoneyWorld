namespace BankSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientContactColumnNamesChanged : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ClientContacts", name: "Owner_Id_Id", newName: "Owner_Id");
            RenameColumn(table: "dbo.ClientContacts", name: "Target_Id_Id", newName: "Target_Id");
            RenameIndex(table: "dbo.ClientContacts", name: "IX_Target_Id_Id", newName: "IX_Target_Id");
            RenameIndex(table: "dbo.ClientContacts", name: "IX_Owner_Id_Id", newName: "IX_Owner_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ClientContacts", name: "IX_Owner_Id", newName: "IX_Owner_Id_Id");
            RenameIndex(table: "dbo.ClientContacts", name: "IX_Target_Id", newName: "IX_Target_Id_Id");
            RenameColumn(table: "dbo.ClientContacts", name: "Target_Id", newName: "Target_Id_Id");
            RenameColumn(table: "dbo.ClientContacts", name: "Owner_Id", newName: "Owner_Id_Id");
        }
    }
}
