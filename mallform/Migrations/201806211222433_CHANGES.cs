namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CHANGES : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.leaseStatus", newName: "States");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.States", newName: "leaseStatus");
        }
    }
}
