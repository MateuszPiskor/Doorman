using System.ComponentModel.DataAnnotations;

namespace Doorman.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string Department { get; set; }
        [Required]
        [StringLength(50)]
        public string Position { get; set; }
    }
}
