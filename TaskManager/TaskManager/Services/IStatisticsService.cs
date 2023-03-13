namespace TaskManager.Services
{
    public interface IStatisticsService
    {
        int GetEmployeesCount();

        int GetTasksCount();

        int GetTeamsCount();

        decimal GetTotalSalary();
    }
}
