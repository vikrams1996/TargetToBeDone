namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droper : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "rentId", "dbo.Rents");
            DropIndex("dbo.Invoices", new[] { "rentId" });
            DropColumn("dbo.Invoices", "rentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "rentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoices", "rentId");
            AddForeignKey("dbo.Invoices", "rentId", "dbo.Rents", "Id", cascadeDelete: false);
        }
    }
}
