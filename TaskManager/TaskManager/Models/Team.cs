namespace TaskManager.Models
{
    public class Team
    {
        public Team()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
