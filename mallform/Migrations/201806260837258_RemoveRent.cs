namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FileUploads", "Rent_Id", "dbo.Rents");
            DropIndex("dbo.FileUploads", new[] { "Rent_Id" });
            DropColumn("dbo.FileUploads", "Rent_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FileUploads", "Rent_Id", c => c.Int());
            CreateIndex("dbo.FileUploads", "Rent_Id");
            AddForeignKey("dbo.FileUploads", "Rent_Id", "dbo.Rents", "Id");
        }
    }
}
