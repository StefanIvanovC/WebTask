using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace EmployeeTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<TaskManager.Models.Task> Task { get; set; }

        public DbSet<Team> Teams { get; set; }
    }
}
