using EmployeeLeaves.Data;
using EmployeeLeaves.Enums;
using EmployeeLeaves.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EmployeeLeaves.Controllers
{
    public class EmployeeStatisticsController : Controller
    {
        private readonly LeavesContext _context;

        public EmployeeStatisticsController(LeavesContext context)
        {
            _context = context;
        }
        public IActionResult Index(int EmployeeID, int? Year)
        {
            var employee = _context.Employees.Include(e => e.LeaveRequests).ThenInclude(r => r.RequestedDays).FirstOrDefault<Employee>(e => e.Id == EmployeeID);

            var leaveRequests = _context.LeaveRequests.Include(l => l.Employee).Include(l => l.RequestedDays).Where(l => l.EmployeeId == EmployeeID);

            if (employee == null)
                return NotFound();

            EmployeeStatisticsViewModel employeeStatistics = new EmployeeStatisticsViewModel();

            employeeStatistics.Employee = employee;
            employeeStatistics.Year = Year ?? DateTime.Now.Year;

            employeeStatistics.LeaveRequests = employee.LeaveRequests.ToList();

            employeeStatistics.AnnualLeaveDays = 25;

            var leaveDaysDictionary = employee.LeaveRequests
                .Where(x => x.Status == RequestStatus.Approved)
                .SelectMany(x => x.RequestedDays)
                .Select(i => i.LeaveDay)
                .GroupBy(i => i.Month)
                .Select(i => new { minas = new DateTime(2025, i.Key, 1).ToString("MMM", CultureInfo.InvariantCulture).ToUpper(), count = i.Count() })
                .ToDictionary(i => i.minas, i => i.count);

            var dict = new Dictionary<string, int>();

            for (int i = 1; i <= 12; i++)
            {
                DateOnly d = new DateOnly(2025, i, 1);
                string key = d.ToString("MMM", CultureInfo.InvariantCulture).ToUpper();
                dict.Add(key, GetValueFromDictionary(leaveDaysDictionary, key));
            }

            employeeStatistics.LeaveDaysApproved = employee.LeaveRequests.Where(x => x.Status == RequestStatus.Approved).SelectMany(x => x.RequestedDays).Count();
            employeeStatistics.LeaveDaysPendingApproval = employee.LeaveRequests.Where(x => x.Status == RequestStatus.Pending).SelectMany(x => x.RequestedDays).Count();
            employeeStatistics.LeaveDaysRejected = employee.LeaveRequests.Where(x => x.Status == RequestStatus.Rejected).SelectMany(x => x.RequestedDays).Count(); ;
            employeeStatistics.LeaveDaysRemaining = employeeStatistics.AnnualLeaveDays - employeeStatistics.LeaveDaysApproved - employeeStatistics.LeaveDaysPendingApproval - employeeStatistics.LeaveDaysRejected;
            employeeStatistics.LeaveDaysPerMonth = dict;

            return View(employeeStatistics);
        }

        private int GetValueFromDictionary(Dictionary<string, int> dic, string key)
        {
            foreach(KeyValuePair<string, int> entry in dic)
            {
                if (entry.Key == key)
                    return entry.Value;
            }
            return 0;
        }

    }
}

