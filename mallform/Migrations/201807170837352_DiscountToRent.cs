namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountToRent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rents", "Discount", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rents", "Discount");
        }
    }
}
