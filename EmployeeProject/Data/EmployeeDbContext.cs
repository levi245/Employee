using EmployeeProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.Data
{
    public class EmployeeDbContext : DbContext  
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Skill>().ToTable("Skills");
            modelBuilder.Entity<EmployeeSkill>().ToTable("EmployeeSkills");



        }


    }
}

