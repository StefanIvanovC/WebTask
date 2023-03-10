using System.ComponentModel.DataAnnotations;

namespace EmployeeTask.Data.Models
{
    public class Employee
    {
        public Employee()
        {
            this.Tasks = new HashSet<Task>();
            this.DateOfBirth = DateTime.MinValue;
        }

        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int MontlySalary { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
