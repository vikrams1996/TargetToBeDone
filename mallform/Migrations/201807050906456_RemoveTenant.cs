namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTenant : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Invoices", "Tenant");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "Tenant", c => c.String());
        }
    }
}
