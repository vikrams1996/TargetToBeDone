namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntAmountToRent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rents", "Amount", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rents", "Amount", c => c.String());
        }
    }
}
