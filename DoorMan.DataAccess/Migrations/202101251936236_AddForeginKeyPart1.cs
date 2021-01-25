namespace DoorMan.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeginKeyPart1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KeyEntities", "EmployeeId", c => c.Int());

            Sql(@"UPDATE dbo.KeyEntities SET EmployeeId = 1
              where EmployeeId IS NULL");
        }
        
        public override void Down()
        {
            DropColumn("dbo.KeyEntities", "EmployeeId");
        }
    }
}
