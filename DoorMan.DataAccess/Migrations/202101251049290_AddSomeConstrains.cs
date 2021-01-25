namespace DoorMan.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeConstrains : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeEnts", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeEnts", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeEnts", "Department", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeEnts", "Department", c => c.String());
            AlterColumn("dbo.EmployeeEnts", "LastName", c => c.String());
            AlterColumn("dbo.EmployeeEnts", "FirstName", c => c.String());
        }
    }
}
