namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AplliedNumberAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tenants", "mobileNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tenants", "mobileNo", c => c.String(maxLength: 10));
        }
    }
}
