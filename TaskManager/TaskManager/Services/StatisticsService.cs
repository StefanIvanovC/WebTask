using EmployeeTask.Data;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext _context;

        public StatisticsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetEmployeesCount()
        {
            return _context.Employees.Count();
        }

        public int GetTasksCount()
        {
            return _context.Task.Count();
        }

        public int GetTeamsCount()
        {
            return _context.Teams.Count();
        }

        public decimal GetTotalSalary()
        {
            return _context.Employees.Sum(e => e.MonthlySalary);
        }
    }
}
