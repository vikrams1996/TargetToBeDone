namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveEntity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Invoices", "AmountToPay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "AmountToPay", c => c.String());
        }
    }
}
