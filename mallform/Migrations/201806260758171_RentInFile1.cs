namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentInFile1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileUploads", "RentId", c => c.Int(nullable: true));
            CreateIndex("dbo.FileUploads", "RentId");
            AddForeignKey("dbo.FileUploads", "RentId", "dbo.Rents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileUploads", "RentId", "dbo.Rents");
            DropIndex("dbo.FileUploads", new[] { "RentId" });
            DropColumn("dbo.FileUploads", "RentId");
        }
    }
}
