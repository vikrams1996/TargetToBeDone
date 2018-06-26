namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droped : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "FileUpload_ID", "dbo.FileUploads");
            DropIndex("dbo.Rents", new[] { "FileUpload_ID" });
            DropColumn("dbo.Rents", "fileId");
            DropColumn("dbo.Rents", "FileUpload_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rents", "FileUpload_ID", c => c.Int());
            AddColumn("dbo.Rents", "fileId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rents", "FileUpload_ID");
            AddForeignKey("dbo.Rents", "FileUpload_ID", "dbo.FileUploads", "ID");
        }
    }
}
