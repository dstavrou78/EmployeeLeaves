using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeLeaves.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string Firstname { get; set; } = String.Empty;

        [NotMapped]
        [DisplayName("Name")]
        public string FullName => $"{Lastname} {Firstname}";
        public string Email { get; set; } = String.Empty;
        [DisplayName("Date of birth"), DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [DisplayName("Date of hire"), DataType(DataType.Date)]
        public DateTime? DateOfHire { get; set; }
        [DisplayName("Date of redundancy"), DataType(DataType.Date)]
        public DateTime? DateOfRedundancy { get; set; }
        [Required]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [DisplayName("Approver")]
        [Required]
        public int ApproverId { get; set; }
        [DisplayName("Is Approver")]
        public bool IsApprover { get; set; } = false;
        [DisplayName("Is Manager")]
        public bool IsManager { get; set; } = false;
        [DisplayName("Is Administrator")]
        public bool IsAdmin { get; set; } = false;
        public virtual Department? Department { get; set; }
        public virtual Employee? Approver { get; set; }
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
    }
}
