namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class leaseStatusTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.leaseStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.leaseStatus");
        }
    }
}
