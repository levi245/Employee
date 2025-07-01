using AutoMapper;
using EmployeeProject.Data;
using EmployeeProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.Repository
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext dbContext;

        public SQLEmployeeRepository(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingEmployee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (existingEmployee == null)
            {
                return false;
            }

            dbContext.Employees.Remove(existingEmployee);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Employee> UpdateAsync(int Id,Employee employee)
        {
            var existingEmployee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == Id);

            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.FullName = employee.FullName;
            existingEmployee.HiredOn = employee.HiredOn;

          //  dbContext.Employees.Update(existingEmployee);
            await dbContext.SaveChangesAsync();

            return existingEmployee;
        }

        async Task<Employee?> IEmployeeRepository.DeleteAsync(int id)
        {
            var existing = await dbContext.Employees.FindAsync(id);
            if (existing is null) return null;

            dbContext.Employees.Remove(existing);
            await dbContext.SaveChangesAsync();
            return existing;
        }
    }
}
