namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class totalAmountInRent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rents", "totalAmount", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rents", "totalAmount");
        }
    }
}
