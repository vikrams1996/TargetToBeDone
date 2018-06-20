namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredDataAnnotationsToTenantTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tenants", "shopName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tenants", "brandName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tenants", "Address", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tenants", "mobileNo", c => c.String(nullable: false));
            AlterColumn("dbo.Tenants", "panNo", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tenants", "panNo", c => c.String(maxLength: 50));
            AlterColumn("dbo.Tenants", "mobileNo", c => c.String());
            AlterColumn("dbo.Tenants", "Address", c => c.String(maxLength: 50));
            AlterColumn("dbo.Tenants", "brandName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Tenants", "shopName", c => c.String(maxLength: 50));
        }
    }
}
