using System.ComponentModel.DataAnnotations;

namespace employeetask.Models
{
    public class Employee
    {
        [Key]  // Primary Key
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(18, 65)]
        public int Age { get; set; }

        [Required]
        public string Department { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Salary must be greater than zero")]
        public double Salary { get; set; }
    }
}