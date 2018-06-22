namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropStatusTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.States");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
