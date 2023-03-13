using TaskManager.Models;

namespace TaskManager.ViewModels
{
    public class StatisticsViewModel
    {
        public int EmployeesCount { get; set; }

        public int TasksCount { get; set; }

        public int TeamsCount { get; set; }

        public decimal TotalSalary { get; set; }
    }
}

