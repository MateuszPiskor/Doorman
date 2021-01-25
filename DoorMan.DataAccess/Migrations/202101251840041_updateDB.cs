namespace DoorMan.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EmployeeEnts", newName: "EmployeeEnitities");
            DropForeignKey("dbo.KeyEntities", "Id", "dbo.EmployeeEnts");
            DropIndex("dbo.KeyEntities", new[] { "Id" });
            DropPrimaryKey("dbo.KeyEntities");
            AlterColumn("dbo.KeyEntities", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.KeyEntities", "Id");
            DropColumn("dbo.KeyEntities", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KeyEntities", "EmployeeId", c => c.Int());
            DropPrimaryKey("dbo.KeyEntities");
            AlterColumn("dbo.KeyEntities", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.KeyEntities", "Id");
            CreateIndex("dbo.KeyEntities", "Id");
            AddForeignKey("dbo.KeyEntities", "Id", "dbo.EmployeeEnts", "Id");
            RenameTable(name: "dbo.EmployeeEnitities", newName: "EmployeeEnts");
        }
    }
}
