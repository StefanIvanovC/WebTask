using System.ComponentModel.DataAnnotations;

namespace EmployeeTask.Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public int AssignedEmployeeId { get; set; }

        public virtual Employee AssignedEmployee { get; set; }

        public bool IsCompleted { get; set; }
    }
}
