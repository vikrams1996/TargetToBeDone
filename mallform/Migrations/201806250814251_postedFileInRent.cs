namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postedFileInRent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rents", "postedFile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rents", "postedFile");
        }
    }
}
