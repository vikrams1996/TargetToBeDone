namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FloorShopInUnit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Units", "Floor_Id", c => c.Byte());
            AddColumn("dbo.Units", "Shop_Id", c => c.Int());
            CreateIndex("dbo.Units", "Floor_Id");
            CreateIndex("dbo.Units", "Shop_Id");
            AddForeignKey("dbo.Units", "Floor_Id", "dbo.Floors", "Id");
            AddForeignKey("dbo.Units", "Shop_Id", "dbo.shops", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Units", "Shop_Id", "dbo.shops");
            DropForeignKey("dbo.Units", "Floor_Id", "dbo.Floors");
            DropIndex("dbo.Units", new[] { "Shop_Id" });
            DropIndex("dbo.Units", new[] { "Floor_Id" });
            DropColumn("dbo.Units", "Shop_Id");
            DropColumn("dbo.Units", "Floor_Id");
        }
    }
}
