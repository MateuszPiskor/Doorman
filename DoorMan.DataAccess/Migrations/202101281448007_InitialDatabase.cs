namespace DoorMan.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Keys", "RoomName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Keys", "RoomName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
