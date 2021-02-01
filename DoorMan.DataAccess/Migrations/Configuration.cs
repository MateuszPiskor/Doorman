namespace DoorMan.DataAccess.Migrations
{
    using Doorman.Model;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DoorMan.DataAccess.DoormanDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DoorMan.DataAccess.DoormanDBContext context)
        {
            context.Keys.AddOrUpdate(p => p.RoomNumber,
                getRoomArray());
            
            context.Employees.AddOrUpdate(
              p => p.FirstName,
              new Employee { FirstName = "Mateusz", LastName = "LastName", Department = "Department1", Positon = "Position1" },
              new Employee { FirstName = "Mateusz", LastName = "LastName", Department = "Department2", Positon = "Position2" },
              new Employee { FirstName = "Jagoda", LastName = "LastName", Department = "Department3", Positon = "Position3" },
              new Employee { FirstName = "Jagoda", LastName = "LastName", Department = "Department4", Positon = "Position4" },
              new Employee { FirstName = "Jagoda", LastName = "LastName", Department = "Department5", Positon = "Position5" },
              new Employee { FirstName = "Mateusz", LastName = "LastName", Department = "Department6", Positon = "Position6" },
              new Employee { FirstName = "Czesław", LastName = "LastName", Department = "Department7", Positon = "Position7" },
              new Employee { FirstName = "Monika", LastName = "LastName", Department = "Department8", Positon = "Position8" },
              new Employee { FirstName = "Natalia", LastName = "LastName", Department = "Department9", Positon = "Position9" },
              new Employee { FirstName = "Cecylia", LastName = "LastName", Department = "Department10", Positon = "Position10" },
              new Employee { FirstName = "Mateusz", LastName = "LastName", Department = "Department11", Positon = "Position11" },
              new Employee { FirstName = "Adela", LastName = "LastName", Department = "Department12", Positon = "Position12" },
              new Employee { FirstName = "Aldona", LastName = "LastName", Department = "Department13", Positon = "Position13" },
              new Employee { FirstName = "Aneta", LastName = "LastName", Department = "Department14", Positon = "Position14" },
              new Employee { FirstName = "Antonina", LastName = "LastName", Department = "Department15", Positon = "Position15" },
              new Employee { FirstName = "Bernadeta", LastName = "LastName", Department = "Department16", Positon = "Position16" },
              new Employee { FirstName = "Blanka", LastName = "LastName", Department = "Department17", Positon = "Position17" },
              new Employee { FirstName = "Bożena", LastName = "LastName", Department = "Department18", Positon = "Position18" },
              new Employee { FirstName = "Celina", LastName = "LastName", Department = "Department19", Positon = "Position19" },
              new Employee { FirstName = "Dominika", LastName = "LastName", Department = "Department20", Positon = "Position20" },
              new Employee { FirstName = "Jagoda", LastName = "LastName", Department = "Department21", Positon = "Position21" },
              new Employee { FirstName = "Dorota", LastName = "LastName", Department = "Department22", Positon = "Position22" },
              new Employee { FirstName = "Edyta", LastName = "LastName", Department = "Department23", Positon = "Position23" },
              new Employee { FirstName = "Emilia", LastName = "LastName", Department = "Department24", Positon = "Position24" },
              new Employee { FirstName = "Ewa", LastName = "LastName", Department = "Department25", Positon = "Position25" },
              new Employee { FirstName = "Felicja", LastName = "LastName", Department = "Department26", Positon = "Position26" },
              new Employee { FirstName = "Helena", LastName = "LastName", Department = "Department27", Positon = "Position27" },
              new Employee { FirstName = "Julita", LastName = "LastName", Department = "Department28", Positon = "Position28" },
              new Employee { FirstName = "Justyna", LastName = "LastName", Department = "Department29", Positon = "Position29" },
              new Employee { FirstName = "Kamila", LastName = "LastName", Department = "Department30", Positon = "Position30" },
              new Employee { FirstName = "Jagoda", LastName = "LastName", Department = "Department31", Positon = "Position31" },
              new Employee { FirstName = "Laura", LastName = "LastName", Department = "Department32", Positon = "Position32" },
              new Employee { FirstName = "Kleopatra", LastName = "LastName", Department = "Department33", Positon = "Position33" },
              new Employee { FirstName = "Lidia", LastName = "LastName", Department = "Department34", Positon = "Position34" },
              new Employee { FirstName = "Andrzej", LastName = "LastName", Department = "Department35", Positon = "Position35" },
              new Employee { FirstName = "Luiza", LastName = "LastName", Department = "Departmen36", Positon = "Position36" },
              new Employee { FirstName = "Magdalena", LastName = "LastName", Department = "Department37", Positon = "Position37" },
              new Employee { FirstName = "Olga", LastName = "LastName", Department = "Department38", Positon = "Position38" },
              new Employee { FirstName = "Oliwia", LastName = "LastName", Department = "Department39", Positon = "Position39" },
              new Employee { FirstName = "Roksana", LastName = "LastName", Department = "Department40", Positon = "Position40" },
              new Employee { FirstName = "Sabina", LastName = "LastName", Department = "Department41", Positon = "Position41" },
              new Employee { FirstName = "Sandra", LastName = "LastName", Department = "Department42", Positon = "Position42" },
              new Employee { FirstName = "Stefania", LastName = "LastName", Department = "Department43", Positon = "Position43" },
              new Employee { FirstName = "Stella", LastName = "LastName", Department = "Department44", Positon = "Position44" },
              new Employee { FirstName = "Sonia", LastName = "LastName", Department = "Department45", Positon = "Position45" },
              new Employee { FirstName = "Tamara", LastName = "LastName", Department = "Department46", Positon = "Position46" },
              new Employee { FirstName = "Ursuzla", LastName = "LastName", Department = "Department47", Positon = "Position47" },
              new Employee { FirstName = "Weronika", LastName = "LastName", Department = "Department48", Positon = "Position48" },
              new Employee { FirstName = "Wiktoria", LastName = "LastName", Department = "Department49", Positon = "Position49" },
              new Employee { FirstName = "Wioleta", LastName = "LastName", Department = "Department50", Positon = "Position50" },
              new Employee { FirstName = "Adam", LastName = "LastName", Department = "Department51", Positon = "Position51" },
              new Employee { FirstName = "Adolf", LastName = "LastName", Department = "Department52", Positon = "Position52" },
              new Employee { FirstName = "Adrian", LastName = "LastName", Department = "Department53", Positon = "Position53" },
              new Employee { FirstName = "Antoni", LastName = "LastName", Department = "Department54", Positon = "Position54" },
              new Employee { FirstName = "Arnold", LastName = "LastName", Department = "Department55", Positon = "Position55" },
              new Employee { FirstName = "Bernard", LastName = "LastName", Department = "Department56", Positon = "Position56" },
              new Employee { FirstName = "Borys", LastName = "LastName", Department = "Department57", Positon = "Position57" },
              new Employee { FirstName = "Bronisław", LastName = "LastName", Department = "Department58", Positon = "Position58" },
              new Employee { FirstName = "Bogdan", LastName = "LastName", Department = "Department59", Positon = "Position59" },
              new Employee { FirstName = "Cyprain", LastName = "LastName", Department = "Department60", Positon = "Position60" },
              new Employee { FirstName = "Cyryl", LastName = "LastName", Department = "Department61", Positon = "Position61" },
              new Employee { FirstName = "Damina", LastName = "LastName", Department = "Department62", Positon = "Position62" },
              new Employee { FirstName = "Daniel", LastName = "LastName", Department = "Department63", Positon = "Position63" },
              new Employee { FirstName = "Donalnd", LastName = "LastName", Department = "Departmen64", Positon = "Position64" },
              new Employee { FirstName = "Dawid", LastName = "LastName", Department = "Department65", Positon = "Position65" },
              new Employee { FirstName = "Dionizy", LastName = "LastName", Department = "Department66", Positon = "Position66" },
              new Employee { FirstName = "Dominki", LastName = "LastName", Department = "Department67", Positon = "Position67" },
              new Employee { FirstName = "Dariusz", LastName = "LastName", Department = "Department68", Positon = "Position68" },
              new Employee { FirstName = "Edward", LastName = "LastName", Department = "Department69", Positon = "Position69" },
              new Employee { FirstName = "Gerard", LastName = "LastName", Department = "Department70", Positon = "Position70" },
              new Employee { FirstName = "Grzegorz", LastName = "LastName", Department = "Department71", Positon = "Position71" },
              new Employee { FirstName = "Gustaw", LastName = "LastName", Department = "Department72", Positon = "Position72" },
              new Employee { FirstName = "Henryk", LastName = "LastName", Department = "Department73", Positon = "Position73" },
              new Employee { FirstName = "Hubert", LastName = "LastName", Department = "Department74", Positon = "Position74" },
              new Employee { FirstName = "Hilary", LastName = "LastName", Department = "Department75", Positon = "Position75" },
              new Employee { FirstName = "Igancy", LastName = "LastName", Department = "Department76", Positon = "Position76" },
              new Employee { FirstName = "Irendusz", LastName = "LastName", Department = "Department77", Positon = "Position77" },
              new Employee { FirstName = "Igor", LastName = "LastName", Department = "Department78", Positon = "Position78" },
              new Employee { FirstName = "Jacek", LastName = "LastName", Department = "Department79", Positon = "Position79" },
              new Employee { FirstName = "Kacper", LastName = "LastName", Department = "Department80", Positon = "Position80" },
              new Employee { FirstName = "Jan", LastName = "LastName", Department = "Department81", Positon = "Position81" },
              new Employee { FirstName = "Janusz", LastName = "LastName", Department = "Department82", Positon = "Position82" },
              new Employee { FirstName = "Jakub", LastName = "LastName", Department = "Department83", Positon = "Position83" },
              new Employee { FirstName = "Julian", LastName = "LastName", Department = "Department84", Positon = "Position84" },
              new Employee { FirstName = "Juliusz", LastName = "LastName", Department = "Department85", Positon = "Position85" },
              new Employee { FirstName = "Luiza", LastName = "LastName", Department = "Departmen86", Positon = "Position86" },
              new Employee { FirstName = "Magdalena", LastName = "LastName", Department = "Department87", Positon = "Position87" },
              new Employee { FirstName = "Olga", LastName = "LastName", Department = "Department88", Positon = "Position88" },
              new Employee { FirstName = "Oliwia", LastName = "LastName", Department = "Department89", Positon = "Position89" },
              new Employee { FirstName = "Roksana", LastName = "LastName", Department = "Department90", Positon = "Position90" },
              new Employee { FirstName = "Sabina", LastName = "LastName", Department = "Department91", Positon = "Position91" },
              new Employee { FirstName = "Sandra", LastName = "LastName", Department = "Department92", Positon = "Position92" },
              new Employee { FirstName = "Stefania", LastName = "LastName", Department = "Department93", Positon = "Position93" },
              new Employee { FirstName = "Stella", LastName = "LastName", Department = "Department94", Positon = "Position94" },
              new Employee { FirstName = "Sonia", LastName = "LastName", Department = "Department95", Positon = "Position95" },
              new Employee { FirstName = "Tamara", LastName = "LastName", Department = "Department96", Positon = "Position96" },
              new Employee { FirstName = "Ursuzla", LastName = "LastName", Department = "Department97", Positon = "Position97" },
              new Employee { FirstName = "Weronika", LastName = "LastName", Department = "Department98", Positon = "Position98" },
              new Employee { FirstName = "Wiktoria", LastName = "LastName", Department = "Department99", Positon = "Position99" },
              new Employee { FirstName = "Wioleta", LastName = "LastName", Department = "Department100", Positon = "Position100" }

            );
        }

        private Key[] getRoomArray()
        {
            List<Key> keys = new List<Key>();
            for (int i = 0; i < 200; i++)
            {
                keys.Add(new Key() { RoomNumber = InitialNextIdWithZeros(i), RoomName = "Room" + (i+1) });
            }
            return keys.ToArray();
        }
        private static string InitialNextIdWithZeros(int number)
        {
            string IdWithInitialZeros = "";
            number += 1;

            string numerAsAString = number.ToString();

            IdWithInitialZeros += numerAsAString;

            while (IdWithInitialZeros.Length < 4)
            {
                IdWithInitialZeros = IdWithInitialZeros.Insert(0, "0");
            }
            return IdWithInitialZeros;
        }
    }
}
