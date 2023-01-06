using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Band { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string Responsibilities { get; set; }
    }
}
