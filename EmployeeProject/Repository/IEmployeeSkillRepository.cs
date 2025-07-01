using EmployeeProject.Models;

namespace EmployeeProject.Repository
{
    public interface IEmployeeSkillRepository
    {
        Task<IEnumerable<EmployeeSkill>> GetAllAsync();
        Task<EmployeeSkill> GetByIdAsync(int id);
        Task<EmployeeSkill> CreateAsync(EmployeeSkill employeeSkill);
        Task<EmployeeSkill?> UpdateAsync(int employeeId, EmployeeSkill employeeSkill);
        Task<EmployeeSkill?> DeleteAsync(int employeeId, int skillId);
        Task<IEnumerable<EmployeeSkill>> GetSkillsByEmployeeIdAsync(int employeeId);
    }
}
