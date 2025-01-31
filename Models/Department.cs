using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaves.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = String.Empty;
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
