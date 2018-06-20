namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShopAndFloorDropped : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Units", "Floor");
            DropColumn("dbo.Units", "shopNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Units", "shopNo", c => c.String());
            AddColumn("dbo.Units", "Floor", c => c.String());
        }
    }
}
