namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class floorID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Units", "Floor_Id", "dbo.Floors");
            DropIndex("dbo.Units", new[] { "Floor_Id" });
            RenameColumn(table: "dbo.Units", name: "Floor_Id", newName: "floorId");
            AlterColumn("dbo.Units", "floorId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Units", "floorId");
            AddForeignKey("dbo.Units", "floorId", "dbo.Floors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Units", "floorId", "dbo.Floors");
            DropIndex("dbo.Units", new[] { "floorId" });
            AlterColumn("dbo.Units", "floorId", c => c.Byte());
            RenameColumn(table: "dbo.Units", name: "floorId", newName: "Floor_Id");
            CreateIndex("dbo.Units", "Floor_Id");
            AddForeignKey("dbo.Units", "Floor_Id", "dbo.Floors", "Id");
        }
    }
}
