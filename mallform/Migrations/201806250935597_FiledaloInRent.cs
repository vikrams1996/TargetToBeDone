namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FiledaloInRent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rents", "File", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rents", "File");
        }
    }
}
