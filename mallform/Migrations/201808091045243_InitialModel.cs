namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "Unit_Id", "dbo.Units");
            DropForeignKey("dbo.Rents", "Tenant_Id", "dbo.Tenants");
            DropIndex("dbo.Rents", new[] { "Tenant_Id" });
            DropIndex("dbo.Rents", new[] { "Unit_Id" });
            RenameColumn(table: "dbo.Rents", name: "Tenant_Id", newName: "tenantId");
            CreateTable(
                "dbo.FileUploads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        length = c.String(),
                        rentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rents", t => t.rentId, cascadeDelete: true)
                .Index(t => t.rentId);
            
            CreateTable(
                "dbo.Floors",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        startMonth = c.DateTime(nullable: false),
                        endMonth = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        InvoiceStatus = c.String(),
                        Discription = c.String(),
                        rentId = c.Int(nullable: false),
                        invoiceDiscount = c.Int(nullable: false),
                        totalAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rents", t => t.rentId, cascadeDelete: true)
                .Index(t => t.rentId);
            
            CreateTable(
                "dbo.shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Rents", "leaseStatus", c => c.String(nullable: false));
            AddColumn("dbo.Rents", "Discount", c => c.Int(nullable: false));
            AddColumn("dbo.Rents", "totalAmount", c => c.Int(nullable: false));
            AddColumn("dbo.Rents", "IsDiscountGiven", c => c.Boolean(nullable: false));
            AddColumn("dbo.Units", "floorId", c => c.Byte(nullable: false));
            AddColumn("dbo.Units", "shopId", c => c.Int(nullable: false));
            AlterColumn("dbo.Rents", "Amount", c => c.Int(nullable: false));
            AlterColumn("dbo.Rents", "tenantId", c => c.Int(nullable: false));
            AlterColumn("dbo.Units", "Size", c => c.String(nullable: false));
            CreateIndex("dbo.Rents", "tenantId");
            CreateIndex("dbo.Units", "floorId");
            CreateIndex("dbo.Units", "shopId");
            AddForeignKey("dbo.Units", "floorId", "dbo.Floors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Units", "shopId", "dbo.shops", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rents", "tenantId", "dbo.Tenants", "Id", cascadeDelete: true);
            DropColumn("dbo.Rents", "Unit_Id");
            DropColumn("dbo.Units", "Floor");
            DropColumn("dbo.Units", "shopNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Units", "shopNo", c => c.String());
            AddColumn("dbo.Units", "Floor", c => c.String());
            AddColumn("dbo.Rents", "Unit_Id", c => c.Int());
            DropForeignKey("dbo.Rents", "tenantId", "dbo.Tenants");
            DropForeignKey("dbo.Units", "shopId", "dbo.shops");
            DropForeignKey("dbo.Units", "floorId", "dbo.Floors");
            DropForeignKey("dbo.Invoices", "rentId", "dbo.Rents");
            DropForeignKey("dbo.FileUploads", "rentId", "dbo.Rents");
            DropIndex("dbo.Units", new[] { "shopId" });
            DropIndex("dbo.Units", new[] { "floorId" });
            DropIndex("dbo.Invoices", new[] { "rentId" });
            DropIndex("dbo.Rents", new[] { "tenantId" });
            DropIndex("dbo.FileUploads", new[] { "rentId" });
            AlterColumn("dbo.Units", "Size", c => c.String());
            AlterColumn("dbo.Rents", "tenantId", c => c.Int());
            AlterColumn("dbo.Rents", "Amount", c => c.String());
            DropColumn("dbo.Units", "shopId");
            DropColumn("dbo.Units", "floorId");
            DropColumn("dbo.Rents", "IsDiscountGiven");
            DropColumn("dbo.Rents", "totalAmount");
            DropColumn("dbo.Rents", "Discount");
            DropColumn("dbo.Rents", "leaseStatus");
            DropTable("dbo.shops");
            DropTable("dbo.Invoices");
            DropTable("dbo.Floors");
            DropTable("dbo.FileUploads");
            RenameColumn(table: "dbo.Rents", name: "tenantId", newName: "Tenant_Id");
            CreateIndex("dbo.Rents", "Unit_Id");
            CreateIndex("dbo.Rents", "Tenant_Id");
            AddForeignKey("dbo.Rents", "Tenant_Id", "dbo.Tenants", "Id");
            AddForeignKey("dbo.Rents", "Unit_Id", "dbo.Units", "Id");
        }
    }
}
