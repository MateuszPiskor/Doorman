using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.Model
{
    public class Key
    {
        public int Id { get; set; }
        [Required]
        public int RoomNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string RoomName { get; set; }
    }
}
