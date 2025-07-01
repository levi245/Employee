namespace EmployeeUI.DTO
{
    public class Employee
    {
        public int Id { get; set; }

        public string FullName { get; set; } = default!;
        public DateTime HiredOn { get; set; } = DateTime.UtcNow;
    }
}
