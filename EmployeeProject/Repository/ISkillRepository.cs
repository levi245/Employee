using EmployeeProject.Models;

namespace EmployeeProject.Repository
{
    public interface ISkillRepository
    {

        Task<IEnumerable<Skill>> GetAllAsync();
        Task<Skill> GetByIdAsync(int id);
        Task<Skill> CreateAsync(Skill skill);
        Task<Skill?> UpdateAsync(int SkillId, Skill skill);
      
        Task<Skill?> DeleteAsync(int SkillId);
    }
}
