using System.ComponentModel.DataAnnotations;

namespace EmployeeTask.Data.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int BossId { get; set; }

        public virtual Boss Boss { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
