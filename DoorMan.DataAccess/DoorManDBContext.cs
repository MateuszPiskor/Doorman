using Doorman.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorMan.DataAccess
{
    public class DoormanDBContext : DbContext
    {
        public DoormanDBContext() : base("DoormanDb")
        {

        }

        public DbSet<Key> Keys { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<KeyInUse> KeysInUse { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Entity<EmployeeEnitity>();
            //.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
