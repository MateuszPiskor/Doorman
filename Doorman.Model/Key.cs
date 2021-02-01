using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.Model
{
    public class Key
    {
        public int Id { get; set; }
        [Required]
        [StringLength(4)]
        [Index(IsUnique = true)]
        public string RoomNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string RoomName { get; set; }
    }
}
