namespace DoorMan.DataAccess.Migrations
{
    using Doorman.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DoorMan.DataAccess.DoormanDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DoorMan.DataAccess.DoormanDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Keys.AddOrUpdate(
              p => p.RoomNumber,
              new Key { RoomNumber = 101, RoomName = "Room1", },
              new Key { RoomNumber = 102, RoomName = "Room2", },
              new Key { RoomNumber = 103, RoomName = "Room3", },
              new Key { RoomNumber = 104, RoomName = "Room4", },
              new Key { RoomNumber = 105, RoomName = "Room5", },
              new Key { RoomNumber = 106, RoomName = "Room6", },
              new Key { RoomNumber = 107, RoomName = "Room7", },
              new Key { RoomNumber = 108, RoomName = "Room8", },
              new Key { RoomNumber = 109, RoomName = "Room9", },
              new Key { RoomNumber = 110, RoomName = "Room10", }
            );

            context.Employees.AddOrUpdate(
              p => p.FirstName,
              new Employee { FirstName = "FirstName1", LastName = "LastName1",Department="Department1",Position="Position1" },
              new Employee { FirstName = "FirstName2", LastName = "LastName2",Department="Department2",Position="Position2" },
              new Employee { FirstName = "FirstName3", LastName = "LastName3",Department="Department3",Position="Position3" },
              new Employee { FirstName = "FirstName4", LastName = "LastName4",Department="Department4",Position="Position4" },
              new Employee { FirstName = "FirstName5", LastName = "LastName5",Department="Department5",Position="Position5" },
              new Employee { FirstName = "FirstName6", LastName = "LastName6",Department="Department6",Position="Position6" },
              new Employee { FirstName = "FirstName7", LastName = "LastName7",Department="Department7",Position="Position7" },
              new Employee { FirstName = "FirstName8", LastName = "LastName8",Department="Department8",Position="Position8" },
              new Employee { FirstName = "FirstName9", LastName = "LastName9",Department="Department9",Position="Position9" },
              new Employee { FirstName = "FirstName10", LastName = "LastName10",Department="Department10",Position="Position10" }
            );
        }
    }
}
