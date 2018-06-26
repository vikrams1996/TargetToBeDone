namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CLEANED : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FileUploads", "RentId", "dbo.Rents");
            DropIndex("dbo.FileUploads", new[] { "RentId" });
            DropColumn("dbo.FileUploads", "RentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FileUploads", "RentId", c => c.Int(nullable: false));
            CreateIndex("dbo.FileUploads", "RentId");
            AddForeignKey("dbo.FileUploads", "RentId", "dbo.Rents", "Id", cascadeDelete: true);
        }
    }
}
