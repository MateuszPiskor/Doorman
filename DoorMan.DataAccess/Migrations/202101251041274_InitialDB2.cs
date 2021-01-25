namespace DoorMan.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KeyEntities", "RoomNumbers", c => c.Int(nullable: false));
            DropColumn("dbo.KeyEntities", "RoomNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KeyEntities", "RoomNumber", c => c.Int(nullable: false));
            DropColumn("dbo.KeyEntities", "RoomNumbers");
        }
    }
}
