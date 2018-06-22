namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDinUNITS : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Units", "Floor_Id", "dbo.Floors");
            DropIndex("dbo.Units", new[] { "Floor_Id" });
            RenameColumn(table: "dbo.Units", name: "Floor_Id", newName: "FloorId");
            AddColumn("dbo.Units", "ShopId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Units", "FloorId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Units", "FloorId");
            AddForeignKey("dbo.Units", "FloorId", "dbo.Floors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Units", "FloorId", "dbo.Floors");
            DropIndex("dbo.Units", new[] { "FloorId" });
            AlterColumn("dbo.Units", "FloorId", c => c.Byte());
            DropColumn("dbo.Units", "ShopId");
            RenameColumn(table: "dbo.Units", name: "FloorId", newName: "Floor_Id");
            CreateIndex("dbo.Units", "Floor_Id");
            AddForeignKey("dbo.Units", "Floor_Id", "dbo.Floors", "Id");
        }
    }
}
