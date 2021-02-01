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
            context.Keys.AddOrUpdate(
              p => p.RoomNumber,
              new Key { RoomNumber = "0101", RoomName = "Room1", },
              new Key { RoomNumber = "0102", RoomName = "Room2", },
              new Key { RoomNumber = "0103", RoomName = "Room3", },
              new Key { RoomNumber = "0104", RoomName = "Room4", },
              new Key { RoomNumber = "0105", RoomName = "Room5", },
              new Key { RoomNumber = "0106", RoomName = "Room6", },
              new Key { RoomNumber = "0107", RoomName = "Room7", },
              new Key { RoomNumber = "0108", RoomName = "Room8", },
              new Key { RoomNumber = "0109", RoomName = "Room9", },
              new Key { RoomNumber = "0110", RoomName = "Room10", }
            );

            context.Employees.AddOrUpdate(
              p => p.FirstName,
              new Employee { FirstName = "FirstName1", LastName = "LastName1", Department = "Department1", Positon = "Position1" },
              new Employee { FirstName = "FirstName2", LastName = "LastName2", Department = "Department2", Positon = "Position2" },
              new Employee { FirstName = "FirstName3", LastName = "LastName3", Department = "Department3", Positon = "Position3" },
              new Employee { FirstName = "FirstName4", LastName = "LastName4", Department = "Department4", Positon = "Position4" },
              new Employee { FirstName = "FirstName5", LastName = "LastName5", Department = "Department5", Positon = "Position5" },
              new Employee { FirstName = "FirstName6", LastName = "LastName6", Department = "Department6", Positon = "Position6" },
              new Employee { FirstName = "FirstName7", LastName = "LastName7", Department = "Department7", Positon = "Position7" },
              new Employee { FirstName = "FirstName8", LastName = "LastName8", Department = "Department8", Positon = "Position8" },
              new Employee { FirstName = "FirstName9", LastName = "LastName9", Department = "Department9", Positon = "Position9" },
              new Employee { FirstName = "FirstName10", LastName = "LastName10", Department = "Department10", Positon = "Position10" }
            );
        }
    }
}
