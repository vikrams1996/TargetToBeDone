namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteRentColoumnPostedFile : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rents", "postedFile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rents", "postedFile", c => c.String());
        }
    }
}
