using EmployeeTask.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeTask.Data.Models.Task> Task { get; set; }
    }
}
