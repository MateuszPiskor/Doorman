namespace DoorMan.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Keys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomNumber = c.Int(nullable: false),
                        RoomName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Keys");
        }
    }
}
