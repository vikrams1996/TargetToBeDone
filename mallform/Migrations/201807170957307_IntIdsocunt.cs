namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntIdsocunt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rents", "Discount", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rents", "Discount", c => c.String());
        }
    }
}
