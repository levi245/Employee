using System.ComponentModel.DataAnnotations;

namespace EmployeeProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string FullName { get; set; } = default!;
        public DateTime HiredOn { get; set; } = DateTime.UtcNow;

        // many skills *with details*
       
    }
}

