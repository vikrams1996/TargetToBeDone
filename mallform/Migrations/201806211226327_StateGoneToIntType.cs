namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StateGoneToIntType : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.States");
            AlterColumn("dbo.States", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.States", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.States");
            AlterColumn("dbo.States", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.States", "Id");
        }
    }
}
