namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FreshCleanStart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "tenantId", "dbo.Tenants");
            DropForeignKey("dbo.Rents", "unitId", "dbo.Units");
            DropIndex("dbo.Rents", new[] { "tenantId" });
            DropIndex("dbo.Rents", new[] { "unitId" });
            RenameColumn(table: "dbo.Rents", name: "tenantId", newName: "Tenant_Id");
            RenameColumn(table: "dbo.Rents", name: "unitId", newName: "Unit_Id");
            AlterColumn("dbo.Rents", "Tenant_Id", c => c.Int());
            AlterColumn("dbo.Rents", "Unit_Id", c => c.Int());
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
            AlterColumn("dbo.Rents", "Unit_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Rents", "Tenant_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Rents", name: "Unit_Id", newName: "unitId");
            RenameColumn(table: "dbo.Rents", name: "Tenant_Id", newName: "tenantId");
            CreateIndex("dbo.Rents", "unitId");
            CreateIndex("dbo.Rents", "tenantId");
            AddForeignKey("dbo.Rents", "unitId", "dbo.Units", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rents", "tenantId", "dbo.Tenants", "Id", cascadeDelete: true);
        }
    }
}
