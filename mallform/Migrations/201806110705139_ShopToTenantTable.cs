namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShopToTenantTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tenants", "Shop_Id", c => c.Int());
            CreateIndex("dbo.Tenants", "Shop_Id");
            AddForeignKey("dbo.Tenants", "Shop_Id", "dbo.Shops", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tenants", "Shop_Id", "dbo.Shops");
            DropIndex("dbo.Tenants", new[] { "Shop_Id" });
            DropColumn("dbo.Tenants", "Shop_Id");
        }
    }
}
