using EmployeeLeaves.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaves.Models
{
    public class LeaveRequest
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Date of Request")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public RequestStatus Status { get; set; } = Enums.RequestStatus.Pending;
        [DisplayName("Date of Response")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? ResponseDate { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public List<RequestedDay> RequestedDays { get; set; } = new List<RequestedDay>();


}
}
