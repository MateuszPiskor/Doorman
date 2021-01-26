using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.Model
{
    public class KeyInUse
    {
        [Key]
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int? KeyId { get; set; }
        public virtual Key Key { get; set; }
    }
}
