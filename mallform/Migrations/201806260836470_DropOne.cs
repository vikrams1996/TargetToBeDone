namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropOne : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FileUploads", "RentId", "dbo.Rents");
            DropIndex("dbo.FileUploads", new[] { "RentId" });
            RenameColumn(table: "dbo.FileUploads", name: "RentId", newName: "Rent_Id");
            AlterColumn("dbo.FileUploads", "Rent_Id", c => c.Int());
            CreateIndex("dbo.FileUploads", "Rent_Id");
            AddForeignKey("dbo.FileUploads", "Rent_Id", "dbo.Rents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileUploads", "Rent_Id", "dbo.Rents");
            DropIndex("dbo.FileUploads", new[] { "Rent_Id" });
            AlterColumn("dbo.FileUploads", "Rent_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.FileUploads", name: "Rent_Id", newName: "RentId");
            CreateIndex("dbo.FileUploads", "RentId");
            AddForeignKey("dbo.FileUploads", "RentId", "dbo.Rents", "Id", cascadeDelete: true);
        }
    }
}
