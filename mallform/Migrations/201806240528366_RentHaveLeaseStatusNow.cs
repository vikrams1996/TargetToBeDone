namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentHaveLeaseStatusNow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rents", "leaseStatus", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rents", "leaseStatus");
        }
    }
}
