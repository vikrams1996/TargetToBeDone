namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceTabel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        startMonth = c.DateTime(nullable: false),
                        endMonth = c.DateTime(nullable: false),
                        amountPaid = c.String(),
                        amountDue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Invoices");
        }
    }
}
