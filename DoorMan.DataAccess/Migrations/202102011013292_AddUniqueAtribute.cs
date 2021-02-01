namespace DoorMan.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueAtribute : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Keys", new[] { "RoomNumber" });
            AlterColumn("dbo.Keys", "RoomNumber", c => c.String(nullable: false, maxLength: 4));
            CreateIndex("dbo.Keys", "RoomNumber", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Keys", new[] { "RoomNumber" });
            AlterColumn("dbo.Keys", "RoomNumber", c => c.String(maxLength: 4));
            CreateIndex("dbo.Keys", "RoomNumber", unique: true);
        }
    }
}
