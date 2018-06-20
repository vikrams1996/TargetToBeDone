namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iddropped : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Units", "FloorId", "dbo.Floors");
            DropIndex("dbo.Units", new[] { "FloorId" });
            RenameColumn(table: "dbo.Units", name: "FloorId", newName: "Floor_Id");
            AlterColumn("dbo.Units", "Floor_Id", c => c.Byte());
            CreateIndex("dbo.Units", "Floor_Id");
            AddForeignKey("dbo.Units", "Floor_Id", "dbo.Floors", "Id");
            DropColumn("dbo.Units", "ShopId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Units", "ShopId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Units", "Floor_Id", "dbo.Floors");
            DropIndex("dbo.Units", new[] { "Floor_Id" });
            AlterColumn("dbo.Units", "Floor_Id", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.Units", name: "Floor_Id", newName: "FloorId");
            CreateIndex("dbo.Units", "FloorId");
            AddForeignKey("dbo.Units", "FloorId", "dbo.Floors", "Id", cascadeDelete: true);
        }
    }
}
