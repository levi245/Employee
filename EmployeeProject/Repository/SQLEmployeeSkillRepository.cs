using EmployeeProject.Data;
using EmployeeProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.Repository
{
    //public class SQLEmployeeSkillRepository : IEmployeeSkillRepository
    //{

    //    private readonly EmployeeDbContext _dbContext;
    //    public SQLEmployeeSkillRepository(EmployeeDbContext dbContext)
    //    {
    //        dbContext = _dbContext;
    //    }



    //    public async Task<EmployeeSkill> CreateAsync(EmployeeSkill employeeSkill)
    //    {

    //        if (employeeSkill == null) throw new ArgumentNullException(nameof(employeeSkill));

    //        await _dbContext.EmployeeSkills.AddAsync(employeeSkill);
    //        await _dbContext.SaveChangesAsync();
    //        return employeeSkill;
    //    }

    //    public Task<EmployeeSkill?> DeleteAsync(int employeeId, int skillId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public async Task<IEnumerable<EmployeeSkill>> GetAllAsync()
    //    {
    //        return await _dbContext.EmployeeSkills
    //            .Include(es => es.Employee)
    //            .Include(es => es.Skill)
    //            .ToListAsync();
    //        throw new NotImplementedException();
    //    }

    //    public async Task<EmployeeSkill> GetByIdAsync(int id)
    //    {
    //    return await _dbContext.EmployeeSkills
    //            .Include(es => es.Employee)
    //            .Include(es => es.Skill)
    //            .FirstOrDefaultAsync(es => es.Id == id);

    //    }

    //    public async Task<IEnumerable<EmployeeSkill>> GetSkillsByEmployeeIdAsync(int employeeId)
    //    {

    //        return await _dbContext.EmployeeSkills
    //            .Where(es => es.EmployeeId == employeeId)
    //            .Include(es => es.Skill)
    //            .ToListAsync();

    //    }

    //    public async Task<EmployeeSkill?> UpdateAsync(int employeeId, EmployeeSkill employeeSkill)
    //    {


    //    }
    //}
    public class SQLEmployeeSkillRepository : IEmployeeSkillRepository
    {
        private readonly EmployeeDbContext _dbContext;

        public SQLEmployeeSkillRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE ──────────────────────────────────────────────────────────────
        public async Task<EmployeeSkill> CreateAsync(EmployeeSkill employeeSkill)
        {
            if (employeeSkill is null) throw new ArgumentNullException(nameof(employeeSkill));

            await _dbContext.EmployeeSkills.AddAsync(employeeSkill);
            await _dbContext.SaveChangesAsync();

            // Eager‑load the nav props so caller gets everything
            return await _dbContext.EmployeeSkills
                                   .Include(es => es.Employee)
                                   .Include(es => es.Skill)
                                   .FirstAsync(es => es.Id == employeeSkill.Id);
        }

        // READ ────────────────────────────────────────────────────────────────
        public async Task<IEnumerable<EmployeeSkill>> GetAllAsync() =>
            await _dbContext.EmployeeSkills
                            .Include(es => es.Employee)
                            .Include(es => es.Skill)
                            .ToListAsync();

        public async Task<EmployeeSkill?> GetByIdAsync(int id) =>
            await _dbContext.EmployeeSkills
                            .Include(es => es.Employee)
                            .Include(es => es.Skill)
                            .FirstOrDefaultAsync(es => es.Id == id);

        public async Task<IEnumerable<EmployeeSkill>> GetSkillsByEmployeeIdAsync(int employeeId) =>
            await _dbContext.EmployeeSkills
                            .Where(es => es.EmployeeId == employeeId)
                            .Include(es => es.Skill)
                            .ToListAsync();

        // UPDATE ──────────────────────────────────────────────────────────────
        public async Task<EmployeeSkill?> UpdateAsync(int employeeId, EmployeeSkill patch)
        {
          throw new NotImplementedException();
           
        }

        // DELETE ──────────────────────────────────────────────────────────────
        public async Task<EmployeeSkill?> DeleteAsync(int employeeId, int skillId)
        {
            var existing = await _dbContext.EmployeeSkills
                                           .FirstOrDefaultAsync(es => es.EmployeeId == employeeId
                                                                   && es.SkillId == skillId);

            if (existing is null) return null;

            _dbContext.EmployeeSkills.Remove(existing);
            await _dbContext.SaveChangesAsync();
            return existing;
        }
    }
}

