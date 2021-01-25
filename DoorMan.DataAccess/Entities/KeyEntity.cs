using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorMan.DataAccess.Entities
{
    public class KeyEntity
    {
        [Key]
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string RoomName { get; set; }
        public int? EmployeeId { get; set; }
        public virtual EmployeeEnitity EmployeeEnitity { get; set; }

    }
}
