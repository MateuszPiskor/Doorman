namespace DoorMan.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOnePropertyName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KeyEntities", "RoomNumber", c => c.Int(nullable: false));
            DropColumn("dbo.KeyEntities", "RoomNumbers");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KeyEntities", "RoomNumbers", c => c.Int(nullable: false));
            DropColumn("dbo.KeyEntities", "RoomNumber");
        }
    }
}
