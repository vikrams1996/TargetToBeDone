namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeaseIdinRent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rents", "leaseId", c => c.Byte(nullable: false));
            AddColumn("dbo.Rents", "leaseStatus_Id", c => c.Byte());
            CreateIndex("dbo.Rents", "leaseStatus_Id");
            AddForeignKey("dbo.Rents", "leaseStatus_Id", "dbo.leaseStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "leaseStatus_Id", "dbo.leaseStatus");
            DropIndex("dbo.Rents", new[] { "leaseStatus_Id" });
            DropColumn("dbo.Rents", "leaseStatus_Id");
            DropColumn("dbo.Rents", "leaseId");
        }
    }
}
