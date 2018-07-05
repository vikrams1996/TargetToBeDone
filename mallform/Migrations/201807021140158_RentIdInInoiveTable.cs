namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentIdInInoiveTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "rentId", c => c.Int(nullable: true));
            CreateIndex("dbo.Invoices", "rentId");
            AddForeignKey("dbo.Invoices", "rentId", "dbo.Rents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "rentId", "dbo.Rents");
            DropIndex("dbo.Invoices", new[] { "rentId" });
            DropColumn("dbo.Invoices", "rentId");
        }
    }
}
