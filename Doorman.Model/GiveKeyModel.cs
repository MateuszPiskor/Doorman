using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.Model
{
    public class GiveKeyModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeId { get; set; }
        public int KeyId { get; set; }
        public string ShowEmployeeId { get; set; }
    }
}
