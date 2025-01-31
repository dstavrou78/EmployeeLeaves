using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeLeaves.Models;

namespace EmployeeLeaves.Data
{
    public class LeavesContext : DbContext
    {
        public LeavesContext (DbContextOptions<LeavesContext> options)
            : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.LeaveRequests)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId)
                .IsRequired();

            modelBuilder.Entity<LeaveRequest>()
                .HasMany(e => e.RequestedDays)
                .WithOne(e => e.LeaveRequest)
                .HasForeignKey(e => e.LeaveRequestId)
                .IsRequired();

            modelBuilder.Seed();
        }

        public DbSet<EmployeeLeaves.Models.Department> Departments { get; set; } = default!;
        public DbSet<EmployeeLeaves.Models.Employee> Employees { get; set; } = default!;
        public DbSet<EmployeeLeaves.Models.LeaveRequest> LeaveRequests { get; set; } = default!;
        public DbSet<EmployeeLeaves.Models.RequestedDay> RequestedDays { get; set; } = default!;
    }
}
