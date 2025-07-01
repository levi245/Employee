using EmployeeProject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeProject.DTO
{
    public class AddEmployeeSkillRequestDto
    {
        public int Id { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }

        [ForeignKey("SkillId")]
        public int SkillId { get; set; }

        public Skill Skill { get; set; } = default!;
        public Employee Employee { get; set; } = default!;

    }
}
