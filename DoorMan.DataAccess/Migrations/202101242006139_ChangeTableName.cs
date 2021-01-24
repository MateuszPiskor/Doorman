namespace DoorMan.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Keys", newName: "KeyEntities");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.KeyEntities", newName: "Keys");
        }
    }
}
