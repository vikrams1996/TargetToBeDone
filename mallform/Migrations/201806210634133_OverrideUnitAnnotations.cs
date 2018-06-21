namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideUnitAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Units", "Size", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Units", "Size", c => c.String());
        }
    }
}
