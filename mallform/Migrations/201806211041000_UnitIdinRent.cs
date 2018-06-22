namespace mallform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnitIdinRent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "Unit_Id", "dbo.Units");
            DropIndex("dbo.Rents", new[] { "Unit_Id" });
            RenameColumn(table: "dbo.Rents", name: "Unit_Id", newName: "unitId");
            AlterColumn("dbo.Rents", "unitId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rents", "unitId");
            AddForeignKey("dbo.Rents", "unitId", "dbo.Units", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "unitId", "dbo.Units");
            DropIndex("dbo.Rents", new[] { "unitId" });
            AlterColumn("dbo.Rents", "unitId", c => c.Int());
            RenameColumn(table: "dbo.Rents", name: "unitId", newName: "Unit_Id");
            CreateIndex("dbo.Rents", "Unit_Id");
            AddForeignKey("dbo.Rents", "Unit_Id", "dbo.Units", "Id");
        }
    }
}
