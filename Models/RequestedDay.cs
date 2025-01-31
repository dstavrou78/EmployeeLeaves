using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaves.Models
{
    public class RequestedDay
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime LeaveDay { get; set; }
        public int Year { get; set; }
        public int LeaveRequestId { get; set; }
        public LeaveRequest LeaveRequest { get; set; }

    }
}
