namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cleaned1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "fileId", "dbo.FileUploads");
            DropIndex("dbo.Rents", new[] { "fileId" });
            RenameColumn(table: "dbo.Rents", name: "fileId", newName: "File_ID");
            AlterColumn("dbo.Rents", "File_ID", c => c.Int());
            CreateIndex("dbo.Rents", "File_ID");
            AddForeignKey("dbo.Rents", "File_ID", "dbo.FileUploads", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "File_ID", "dbo.FileUploads");
            DropIndex("dbo.Rents", new[] { "File_ID" });
            AlterColumn("dbo.Rents", "File_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Rents", name: "File_ID", newName: "fileId");
            CreateIndex("dbo.Rents", "fileId");
            AddForeignKey("dbo.Rents", "fileId", "dbo.FileUploads", "ID", cascadeDelete: true);
        }
    }
}
