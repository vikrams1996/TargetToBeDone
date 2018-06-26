namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyInFileUpload : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FileUploads", "Rent_Id", "dbo.Rents");
            DropIndex("dbo.FileUploads", new[] { "Rent_Id" });
            RenameColumn(table: "dbo.FileUploads", name: "Rent_Id", newName: "RentId");
            AlterColumn("dbo.FileUploads", "RentId", c => c.Int(nullable: true));
            CreateIndex("dbo.FileUploads", "RentId");
            AddForeignKey("dbo.FileUploads", "RentId", "dbo.Rents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileUploads", "RentId", "dbo.Rents");
            DropIndex("dbo.FileUploads", new[] { "RentId" });
            AlterColumn("dbo.FileUploads", "RentId", c => c.Int());
            RenameColumn(table: "dbo.FileUploads", name: "RentId", newName: "Rent_Id");
            CreateIndex("dbo.FileUploads", "Rent_Id");
            AddForeignKey("dbo.FileUploads", "Rent_Id", "dbo.Rents", "Id");
        }
    }
}
