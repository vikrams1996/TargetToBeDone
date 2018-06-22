namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropColoumnStatusFromRent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "stateId", "dbo.States");
            DropIndex("dbo.Rents", new[] { "stateId" });
            DropColumn("dbo.Rents", "stateId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rents", "stateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rents", "stateId");
            AddForeignKey("dbo.Rents", "stateId", "dbo.States", "Id", cascadeDelete: true);
        }
    }
}
