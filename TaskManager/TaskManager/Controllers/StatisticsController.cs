using Microsoft.AspNetCore.Mvc;
using TaskManager.Services;
using TaskManager.ViewModels;

namespace TaskManager.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public IActionResult Index()
        {
            var viewModel = new StatisticsViewModel
            {
                EmployeesCount = _statisticsService.GetEmployeesCount(),
                TasksCount = _statisticsService.GetTasksCount(),
                TeamsCount = _statisticsService.GetTeamsCount(),
                TotalSalary = _statisticsService.GetTotalSalary()
            };

            return View(viewModel);
        }
    }
}
