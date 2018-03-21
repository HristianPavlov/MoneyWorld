namespace BankSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSenderIdAndReceiverIdToTransactionModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Transactions", name: "Receiver_Id", newName: "ReceiverId");
            RenameColumn(table: "dbo.Transactions", name: "Sender_Id", newName: "SenderId");
            RenameIndex(table: "dbo.Transactions", name: "IX_Sender_Id", newName: "IX_SenderId");
            RenameIndex(table: "dbo.Transactions", name: "IX_Receiver_Id", newName: "IX_ReceiverId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Transactions", name: "IX_ReceiverId", newName: "IX_Receiver_Id");
            RenameIndex(table: "dbo.Transactions", name: "IX_SenderId", newName: "IX_Sender_Id");
            RenameColumn(table: "dbo.Transactions", name: "SenderId", newName: "Sender_Id");
            RenameColumn(table: "dbo.Transactions", name: "ReceiverId", newName: "Receiver_Id");
        }
    }
}
