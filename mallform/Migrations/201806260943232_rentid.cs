namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rentid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FileUploads", "Rent_Id", "dbo.Rents");
            DropIndex("dbo.FileUploads", new[] { "Rent_Id" });
            RenameColumn(table: "dbo.FileUploads", name: "Rent_Id", newName: "rentId");
            AlterColumn("dbo.FileUploads", "rentId", c => c.Int(nullable: true));
            CreateIndex("dbo.FileUploads", "rentId");
            AddForeignKey("dbo.FileUploads", "rentId", "dbo.Rents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileUploads", "rentId", "dbo.Rents");
            DropIndex("dbo.FileUploads", new[] { "rentId" });
            AlterColumn("dbo.FileUploads", "rentId", c => c.Int());
            RenameColumn(table: "dbo.FileUploads", name: "rentId", newName: "Rent_Id");
            CreateIndex("dbo.FileUploads", "Rent_Id");
            AddForeignKey("dbo.FileUploads", "Rent_Id", "dbo.Rents", "Id");
        }
    }
}
