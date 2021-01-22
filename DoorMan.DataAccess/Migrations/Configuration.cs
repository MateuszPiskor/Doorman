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
            context.Keys.AddOrUpdate(
              p => p.RoomNumber,
              new Key { RoomNumber=101, RoomName = "Room1", },
              new Key { RoomNumber=102, RoomName = "Room2", },
              new Key { RoomNumber= 103, RoomName = "Room3", },
              new Key { RoomNumber=104, RoomName = "Room4", },
              new Key { RoomNumber=105, RoomName = "Room5", },
              new Key { RoomNumber=106, RoomName = "Room6", },
              new Key { RoomNumber=107, RoomName = "Room7", },
              new Key { RoomNumber=108, RoomName = "Room8", },
              new Key { RoomNumber=109, RoomName = "Room9", },
              new Key { RoomNumber=110, RoomName = "Room10", }
            );
            //
        }
    }
}
