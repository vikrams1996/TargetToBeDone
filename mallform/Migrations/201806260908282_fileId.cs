namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fileId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "File_ID", "dbo.FileUploads");
            DropIndex("dbo.Rents", new[] { "File_ID" });
            RenameColumn(table: "dbo.Rents", name: "File_ID", newName: "fileId");
            AlterColumn("dbo.Rents", "fileId", c => c.Int(nullable: true));
            CreateIndex("dbo.Rents", "fileId");
            AddForeignKey("dbo.Rents", "fileId", "dbo.FileUploads", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "fileId", "dbo.FileUploads");
            DropIndex("dbo.Rents", new[] { "fileId" });
            AlterColumn("dbo.Rents", "fileId", c => c.Int());
            RenameColumn(table: "dbo.Rents", name: "fileId", newName: "File_ID");
            CreateIndex("dbo.Rents", "File_ID");
            AddForeignKey("dbo.Rents", "File_ID", "dbo.FileUploads", "ID");
        }
    }
}
