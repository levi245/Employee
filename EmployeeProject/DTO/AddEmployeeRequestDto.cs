using System.ComponentModel.DataAnnotations;

namespace EmployeeProject.DTO
{
    public class AddEmployeeRequestDto
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string FullName { get; set; } = default!;
        public DateTime HiredOn { get; set; } = DateTime.UtcNow;

    }
}
