using Doorman.Model;
using DoorMan.DataAccess.Entities;
using System;
using System.Collections.Generic;
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

        public DbSet<KeyEntity> Keys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                    
        }
    }
}
