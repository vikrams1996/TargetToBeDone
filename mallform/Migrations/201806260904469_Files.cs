namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rents", "fileId", c => c.Int(nullable: true));
            AddColumn("dbo.Rents", "FileUpload_ID", c => c.Int());
            CreateIndex("dbo.Rents", "FileUpload_ID");
            AddForeignKey("dbo.Rents", "FileUpload_ID", "dbo.FileUploads", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "FileUpload_ID", "dbo.FileUploads");
            DropIndex("dbo.Rents", new[] { "FileUpload_ID" });
            DropColumn("dbo.Rents", "FileUpload_ID");
            DropColumn("dbo.Rents", "fileId");
        }
    }
}
