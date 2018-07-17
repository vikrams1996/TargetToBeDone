namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountCheckBox : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rents", "IsDiscountGiven", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rents", "IsDiscountGiven");
        }
    }
}
