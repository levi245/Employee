using EmployeeProject.Data;
using EmployeeProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.Repository
{
    // Fix the typo in the interface name from ISkillRepostory to ISkillRepository
    public class SQLSkillRepository : ISkillRepository
    {
        private readonly EmployeeDbContext _dbContext;

        public SQLSkillRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Skill> CreateAsync(Skill skill)
        {
            if (skill == null) throw new ArgumentNullException(nameof(skill));

            await _dbContext.Skills.AddAsync(skill);
            await _dbContext.SaveChangesAsync();
            return skill;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var skill = await _dbContext.Skills.FindAsync(id);
            if (skill == null) return false;

            _dbContext.Skills.Remove(skill);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Skill>> GetAllAsync()
        {
            return await _dbContext.Skills.ToListAsync();
        }

        public async Task<Skill> GetByIdAsync(int id)
        {
            return await _dbContext.Skills.FindAsync(id);
        }

        public async Task<Skill?> UpdateAsync(int SkillId, Skill skill)
        {
            var existingSkill = await _dbContext.Skills.FirstOrDefaultAsync(x => x.SkillId == SkillId);
            if (existingSkill == null)
            {
                return null; // Return null to match the nullable return type
            }

            existingSkill.SkillName = skill.SkillName;

            await _dbContext.SaveChangesAsync();

            return existingSkill;
        }

       Task<Skill?> ISkillRepository.DeleteAsync(int SkillId)
        {
           var existingSkill = _dbContext.Skills.FirstOrDefaultAsync(x => x.SkillId == SkillId);
            if (existingSkill == null)
            {
                return Task.FromResult<Skill?>(null); // Return null to match the nullable return type
            }
            _dbContext.Skills.Remove(existingSkill.Result);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(existingSkill.Result);
        }

        // Removed the duplicate DeleteAsync method with SkillId parameter to resolve CS0111
    }
}
