namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropAgAIN : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rents", "File");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rents", "File", c => c.String());
        }
    }
}
