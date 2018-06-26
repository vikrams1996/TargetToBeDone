namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileInRent1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rents", "File_ID", c => c.Int());
            CreateIndex("dbo.Rents", "File_ID");
            AddForeignKey("dbo.Rents", "File_ID", "dbo.FileUploads", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "File_ID", "dbo.FileUploads");
            DropIndex("dbo.Rents", new[] { "File_ID" });
            DropColumn("dbo.Rents", "File_ID");
        }
    }
}
