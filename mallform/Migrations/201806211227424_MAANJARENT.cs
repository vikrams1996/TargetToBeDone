namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MAANJARENT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rents", "stateId", c => c.Int(nullable: true));
            CreateIndex("dbo.Rents", "stateId");
            AddForeignKey("dbo.Rents", "stateId", "dbo.States", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "stateId", "dbo.States");
            DropIndex("dbo.Rents", new[] { "stateId" });
            DropColumn("dbo.Rents", "stateId");
        }
    }
}
