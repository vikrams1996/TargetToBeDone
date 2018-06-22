namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DROPPED : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "leaseStatus_Id", "dbo.leaseStatus");
            DropIndex("dbo.Rents", new[] { "leaseStatus_Id" });
            DropColumn("dbo.Rents", "leaseId");
            DropColumn("dbo.Rents", "leaseStatus_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rents", "leaseStatus_Id", c => c.Byte());
            AddColumn("dbo.Rents", "leaseId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Rents", "leaseStatus_Id");
            AddForeignKey("dbo.Rents", "leaseStatus_Id", "dbo.leaseStatus", "Id");
        }
    }
}
