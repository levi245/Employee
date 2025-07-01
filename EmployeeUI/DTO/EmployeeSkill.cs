namespace EmployeeUI.DTO
{
    public class EmployeeSkill
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int SkillId { get; set; }
        public string SkillName { get; set; } // Added property to fix CS1061  
        public Skill Skill { get; set; }
        public Employee Employee { get; set; }
    }
}
