using System.ComponentModel.DataAnnotations;

namespace EmployeeTask.Data.Models
{
    public class Boss
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
