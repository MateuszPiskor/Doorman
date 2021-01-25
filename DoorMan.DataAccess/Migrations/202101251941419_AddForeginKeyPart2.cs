namespace DoorMan.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeginKeyPart2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KeyEntities", "EmployeeEnitity_Id", c => c.Int());
            CreateIndex("dbo.KeyEntities", "EmployeeEnitity_Id");
            AddForeignKey("dbo.KeyEntities", "EmployeeEnitity_Id", "dbo.EmployeeEnitities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KeyEntities", "EmployeeEnitity_Id", "dbo.EmployeeEnitities");
            DropIndex("dbo.KeyEntities", new[] { "EmployeeEnitity_Id" });
            DropColumn("dbo.KeyEntities", "EmployeeEnitity_Id");
        }
    }
}
