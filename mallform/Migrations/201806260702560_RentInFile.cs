namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentInFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileUploads", "Rent_Id", c => c.Int());
            CreateIndex("dbo.FileUploads", "Rent_Id");
            AddForeignKey("dbo.FileUploads", "Rent_Id", "dbo.Rents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileUploads", "Rent_Id", "dbo.Rents");
            DropIndex("dbo.FileUploads", new[] { "Rent_Id" });
            DropColumn("dbo.FileUploads", "Rent_Id");
        }
    }
}
