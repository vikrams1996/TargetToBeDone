namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shopID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Units", "Shop_Id", "dbo.shops");
            DropIndex("dbo.Units", new[] { "Shop_Id" });
            RenameColumn(table: "dbo.Units", name: "Shop_Id", newName: "shopId");
            AlterColumn("dbo.Units", "shopId", c => c.Int(nullable: false));
            CreateIndex("dbo.Units", "shopId");
            AddForeignKey("dbo.Units", "shopId", "dbo.shops", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Units", "shopId", "dbo.shops");
            DropIndex("dbo.Units", new[] { "shopId" });
            AlterColumn("dbo.Units", "shopId", c => c.Int());
            RenameColumn(table: "dbo.Units", name: "shopId", newName: "Shop_Id");
            CreateIndex("dbo.Units", "Shop_Id");
            AddForeignKey("dbo.Units", "Shop_Id", "dbo.shops", "Id");
        }
    }
}
