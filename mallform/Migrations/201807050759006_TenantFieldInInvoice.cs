namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TenantFieldInInvoice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "Tenant", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "Tenant");
        }
    }
}
