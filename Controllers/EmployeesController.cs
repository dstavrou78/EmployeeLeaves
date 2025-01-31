using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeLeaves.Data;
using EmployeeLeaves.Models;

namespace EmployeeLeaves.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly LeavesContext _context;

        public EmployeesController(LeavesContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index(int? page, int? pageSize)
        {
            int _pageSize = (int)(pageSize != null ? pageSize : 10); ;
            int _page = (int)(page != null ? page : 1);
            _page = _page > 0 ? _page : 1;

            var leavesContext = _context.Employees.Include(e => e.Department);

            ViewData["PageNo"] = _page;
            ViewData["PageSize"] = _pageSize;
            ViewData["TotalPages"] = (int)Math.Ceiling((decimal)leavesContext.Count() / _pageSize);

            return View(await leavesContext.Skip((_page - 1) * _pageSize).Take(_pageSize).ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Approver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartmentsList"] = new SelectList(_context.Departments.OrderBy(d => d.Title), "Id", "Title");
            ViewData["ApproversList"] = new SelectList(_context.Employees.Where(e => e.IsApprover == true).OrderBy(e => e.Lastname).ThenBy(e => e.Firstname), "Id", "FullName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Lastname,Firstname,Email,DateOfBirth,DateOfHire,DateOfRedundancy,DepartmentId,ApproverId,IsApprover,IsManager,IsAdmin")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentsList"] = new SelectList(_context.Departments.OrderBy(d => d.Title), "Id", "Title", employee.DepartmentId);
            ViewData["ApproversList"] = new SelectList(_context.Employees.Where(e => e.IsApprover == true).OrderBy(e => e.Lastname).ThenBy(e => e.Firstname), "Id", "FullName", employee.ApproverId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Approver)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentsList"] = new SelectList(_context.Departments.OrderBy(d => d.Title), "Id", "Title", employee.DepartmentId);
            ViewData["ApproversList"] = new SelectList(_context.Employees.Where(e => e.IsApprover == true).OrderBy(e => e.Lastname).ThenBy(e => e.Firstname), "Id", "FullName", employee.ApproverId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Lastname,Firstname,Email,DateOfBirth,DateOfHire,DateOfRedundancy,DepartmentId,ApproverId,IsApprover,IsManager,IsAdmin")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentsList"] = new SelectList(_context.Departments.OrderBy(d => d.Title), "Id", "Title", employee.DepartmentId);
            ViewData["ApproversList"] = new SelectList(_context.Employees.Where(e => e.IsApprover == true).OrderBy(e => e.Lastname).ThenBy(e => e.Firstname), "Id", "FullName", employee.ApproverId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
