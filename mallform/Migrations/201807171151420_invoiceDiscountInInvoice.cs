namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invoiceDiscountInInvoice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "invoiceDiscount", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "invoiceDiscount");
        }
    }
}
