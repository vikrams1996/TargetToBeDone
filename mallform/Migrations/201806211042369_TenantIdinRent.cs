namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TenantIdinRent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "Tenant_Id", "dbo.Tenants");
            DropIndex("dbo.Rents", new[] { "Tenant_Id" });
            RenameColumn(table: "dbo.Rents", name: "Tenant_Id", newName: "tenantId");
            AlterColumn("dbo.Rents", "tenantId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rents", "tenantId");
            AddForeignKey("dbo.Rents", "tenantId", "dbo.Tenants", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "tenantId", "dbo.Tenants");
            DropIndex("dbo.Rents", new[] { "tenantId" });
            AlterColumn("dbo.Rents", "tenantId", c => c.Int());
            RenameColumn(table: "dbo.Rents", name: "tenantId", newName: "Tenant_Id");
            CreateIndex("dbo.Rents", "Tenant_Id");
            AddForeignKey("dbo.Rents", "Tenant_Id", "dbo.Tenants", "Id");
        }
    }
}
