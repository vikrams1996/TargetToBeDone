namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaleKeysIdentified : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Shops", newName: "Units");
        
            AddColumn("dbo.Rents", "Tenant_Id", c => c.Int());
            AddColumn("dbo.Rents", "Unit_Id", c => c.Int());
            CreateIndex("dbo.Rents", "Tenant_Id");
            CreateIndex("dbo.Rents", "Unit_Id");
            AddForeignKey("dbo.Rents", "Tenant_Id", "dbo.Tenants", "Id");
            AddForeignKey("dbo.Rents", "Unit_Id", "dbo.Units", "Id");
           
        }
        
        public override void Down()
        {
           
            
            DropForeignKey("dbo.Rents", "Unit_Id", "dbo.Units");
            DropForeignKey("dbo.Rents", "Tenant_Id", "dbo.Tenants");
            DropIndex("dbo.Rents", new[] { "Unit_Id" });
            DropIndex("dbo.Rents", new[] { "Tenant_Id" });
            DropColumn("dbo.Rents", "Unit_Id");
            DropColumn("dbo.Rents", "Tenant_Id");
            RenameTable(name: "dbo.Units", newName: "Shops");
        }
    }
}
