namespace DoorMan.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Department = c.String(nullable: false, maxLength: 50),
                        Positon = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Keys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomNumber = c.Int(nullable: false),
                        RoomName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KeyInUses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(),
                        KeyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Keys", t => t.KeyId)
                .Index(t => t.EmployeeId)
                .Index(t => t.KeyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KeyInUses", "KeyId", "dbo.Keys");
            DropForeignKey("dbo.KeyInUses", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.KeyInUses", new[] { "KeyId" });
            DropIndex("dbo.KeyInUses", new[] { "EmployeeId" });
            DropTable("dbo.KeyInUses");
            DropTable("dbo.Keys");
            DropTable("dbo.Employees");
        }
    }
}
