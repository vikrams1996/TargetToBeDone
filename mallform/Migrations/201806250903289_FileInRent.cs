namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileInRent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rents", "File", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rents", "File");
        }
    }
}
