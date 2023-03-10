using System.ComponentModel.DataAnnotations;

namespace EmployeeTask.Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Assignee { get; set; }

        public DateTime DueDate { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
