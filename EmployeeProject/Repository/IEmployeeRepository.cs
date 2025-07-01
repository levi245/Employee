using EmployeeProject.Models;

namespace EmployeeProject.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> CreateAsync(Employee employee);
        Task<Employee> UpdateAsync(int Id,Employee employee);
        //Task<bool> DeleteAsync(int id);
        Task<Employee?> DeleteAsync(int id);

       
    }
}
