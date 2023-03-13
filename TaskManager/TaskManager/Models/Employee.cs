namespace TaskManager.Models
{
    public class Employee
    {
        public Employee()
        {
            this.Tasks = new HashSet<Task>();
        }
        public int Id { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal MonthlySalary { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public int? TeamId { get; set; }

        public virtual Team? Team { get; set; }
    }
}
