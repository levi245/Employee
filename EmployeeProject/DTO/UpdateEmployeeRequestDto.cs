using System.ComponentModel.DataAnnotations;

namespace EmployeeProject.DTO
{
    public class UpdateEmployeeRequestDto
    {
     
        [Required, MaxLength(100)]
        public string FullName { get; set; } 
        public DateTime HiredOn { get; set; } = DateTime.UtcNow;
    }
}
