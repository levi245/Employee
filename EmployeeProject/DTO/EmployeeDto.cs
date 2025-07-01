using System.ComponentModel.DataAnnotations;

namespace EmployeeProject.DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }
     
        public string FullName { get; set; } = default!;
        public DateTime HiredOn { get; set; } = DateTime.UtcNow;

    }
}
