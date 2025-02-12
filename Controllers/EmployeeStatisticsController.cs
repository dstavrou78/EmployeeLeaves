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
            int _year = Year ?? DateTime.Now.Year;
            var employee = _context.Employees.Include(e => e.LeaveRequests).ThenInclude(r => r.RequestedDays.Where(k => k.Year == _year)).FirstOrDefault<Employee>(e => e.Id == EmployeeID);
            
            if (employee == null)
                return NotFound();

            EmployeeStatisticsViewModel employeeStatistics = new EmployeeStatisticsViewModel();

            employeeStatistics.Employee = employee;
            employeeStatistics.Year = _year;
            employeeStatistics.LeaveRequests = employee.LeaveRequests.ToList();
            employeeStatistics.AnnualLeaveDays = 25;
            employeeStatistics.LeaveDaysApproved = employee.LeaveRequests.Where(x => x.Status == RequestStatus.Approved).SelectMany(x => x.RequestedDays).Count();
            employeeStatistics.LeaveDaysPendingApproval = employee.LeaveRequests.Where(x => x.Status == RequestStatus.Pending).SelectMany(x => x.RequestedDays).Count();
            employeeStatistics.LeaveDaysRejected = employee.LeaveRequests.Where(x => x.Status == RequestStatus.Rejected).SelectMany(x => x.RequestedDays).Count(); ;
            employeeStatistics.LeaveDaysRemaining = employeeStatistics.AnnualLeaveDays - employeeStatistics.LeaveDaysApproved - employeeStatistics.LeaveDaysPendingApproval;

            var leaveDaysDictionary = employee.LeaveRequests
                .Where(x => x.Status == RequestStatus.Approved)
                .SelectMany(x => x.RequestedDays)
                .Select(i => i.LeaveDay).Where(i => i.Year == _year)
                .GroupBy(i => i.Month)
                .Select(i => new { minas = new DateTime(_year, i.Key, 1).ToString("MMM", CultureInfo.InvariantCulture).ToUpper(), count = i.Count() })
                .ToDictionary(i => i.minas, i => i.count);

            var dict = new Dictionary<string, int>();

            for (int i = 1; i <= 12; i++)
            {
                DateOnly d = new DateOnly(_year, i, 1);
                string key = d.ToString("MMM", CultureInfo.InvariantCulture).ToUpper();
                dict.Add(key, GetValueFromDictionary(leaveDaysDictionary, key));
            }

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

