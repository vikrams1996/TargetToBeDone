namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionInReNTaNDstATE : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.States", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.States", "Name", c => c.String());
        }
    }
}
