namespace EmployeeLeaves.Models
{
    public class EmployeeStatisticsViewModel
    {
        public Employee Employee { get; set; }
        public int Year { get; set; }
        public List<LeaveRequest> LeaveRequests { get; set; }
        public int AnnualLeaveDays { get; set; }
        //public int LeaveDaysApproved { get; set; }
        public int LeaveDaysPendingApproval { get; set; }
        public int LeaveDaysRejected { get; set; }
        public int LeaveDaysRemaining { get; set; }
        public Dictionary<string, int> LeaveDaysPerMonth { get; set; }
        public List<DateTime> LeaveDaysApprovedList { get; set; }

    }
}
