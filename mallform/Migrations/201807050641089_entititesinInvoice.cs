namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entititesinInvoice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Invoices", "AmountToPay", c => c.String());
            AddColumn("dbo.Invoices", "InvoiceStatus", c => c.String());
            AddColumn("dbo.Invoices", "Discription", c => c.String());
            DropColumn("dbo.Invoices", "amountPaid");
            DropColumn("dbo.Invoices", "amountDue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "amountDue", c => c.String());
            AddColumn("dbo.Invoices", "amountPaid", c => c.String());
            DropColumn("dbo.Invoices", "Discription");
            DropColumn("dbo.Invoices", "InvoiceStatus");
            DropColumn("dbo.Invoices", "AmountToPay");
            DropColumn("dbo.Invoices", "CreatedDate");
        }
    }
}
