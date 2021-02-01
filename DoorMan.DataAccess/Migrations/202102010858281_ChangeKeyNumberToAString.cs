namespace DoorMan.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeKeyNumberToAString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Keys", "RoomNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Keys", "RoomNumber", c => c.Int(nullable: false));
        }
    }
}
