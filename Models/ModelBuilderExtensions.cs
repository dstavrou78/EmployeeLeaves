using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaves.Models
{
    public static class ModelBuilderExtensions
    {       public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Title = "Department 1" },
                new Department { Id = 2, Title = "Department 2" },
                new Department { Id = 3, Title = "Department 3" }               
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee {
                    Id = 1,
                    Lastname = "Lastname1",
                    Firstname = "Firstname1",
                    Email = "Email1",
                    DateOfBirth = new DateTime(1978,10,18),
                    DateOfHire = new DateTime(2000,1,1),
                    DateOfRedundancy = null,
                    DepartmentId = 1,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                },
                new Employee
                {
                    Id = 2,
                    Lastname = "Lastname2",
                    Firstname = "Firstname2",
                    Email = "Email2",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 2,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                },
                new Employee
                {
                    Id = 3,
                    Lastname = "Lastname3",
                    Firstname = "Firstname3",
                    Email = "Email3",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 3,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                },
                new Employee
                {
                    Id = 4,
                    Lastname = "Lastname4",
                    Firstname = "Firstname4",
                    Email = "Email4",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 2,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                },
                new Employee
                {
                    Id = 5,
                    Lastname = "Lastname5",
                    Firstname = "Firstname5",
                    Email = "Email5",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 2,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                },
                new Employee
                {
                    Id = 6,
                    Lastname = "Lastname6",
                    Firstname = "Firstname6",
                    Email = "Email6",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 2,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                },
                new Employee
                {
                    Id = 7,
                    Lastname = "Lastname7",
                    Firstname = "Firstname7",
                    Email = "Email7",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 2,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                },
                new Employee
                {
                    Id = 8,
                    Lastname = "Lastname8",
                    Firstname = "Firstname8",
                    Email = "Email8",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 2,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                },
                new Employee
                {
                    Id = 9,
                    Lastname = "Lastname9",
                    Firstname = "Firstname9",
                    Email = "Email9",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 2,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 2
                },
                new Employee
                {
                    Id = 10,
                    Lastname = "Lastname10",
                    Firstname = "Firstname10",
                    Email = "Email10",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 2,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                },
                new Employee
                {
                    Id = 11,
                    Lastname = "Lastname11",
                    Firstname = "Firstname11",
                    Email = "Email11",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 1, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 1,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 2
                },
                new Employee
                {
                    Id = 12,
                    Lastname = "Lastname12",
                    Firstname = "Firstname12",
                    Email = "Email12",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 2,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                },
                new Employee
                {
                    Id = 13,
                    Lastname = "Lastname13",
                    Firstname = "Firstname13",
                    Email = "Email13",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 3,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                },
                new Employee
                {
                    Id = 14,
                    Lastname = "Lastname14",
                    Firstname = "Firstname14",
                    Email = "Email14",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 2,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                },
                new Employee
                {
                    Id = 15,
                    Lastname = "Lastname15",
                    Firstname = "Firstname15",
                    Email = "Email15",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 2,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                },
                new Employee
                {
                    Id = 16,
                    Lastname = "Lastname16",
                    Firstname = "Firstname16",
                    Email = "Email16",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 2,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                },
                new Employee
                {
                    Id = 17,
                    Lastname = "Lastname17",
                    Firstname = "Firstname17",
                    Email = "Email17",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 2,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                },
                new Employee
                {
                    Id = 18,
                    Lastname = "Lastname18",
                    Firstname = "Firstname18",
                    Email = "Email18",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 2,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                },
                new Employee
                {
                    Id = 19,
                    Lastname = "Lastname19",
                    Firstname = "Firstname19",
                    Email = "Email19",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 2,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                },
                new Employee
                {
                    Id = 20,
                    Lastname = "Lastname20",
                    Firstname = "Firstname20",
                    Email = "Email20",
                    DateOfBirth = new DateTime(1978, 10, 18),
                    DateOfHire = new DateTime(2000, 3, 1),
                    DateOfRedundancy = null,
                    DepartmentId = 2,
                    IsAdmin = false,
                    IsApprover = true,
                    IsManager = true,
                    ApproverId = 1
                }
            );

            modelBuilder.Entity<LeaveRequest>().HasData(
                new LeaveRequest { Id = 1, EmployeeId = 1, Status = Enums.RequestStatus.Approved, RequestDate = new DateTime(2025, 01, 10), ResponseDate = new DateTime(2025, 01, 10) },
                new LeaveRequest { Id = 2, EmployeeId = 2, Status = Enums.RequestStatus.Pending, RequestDate = new DateTime(2025, 01, 12), ResponseDate = null },
                new LeaveRequest { Id = 3, EmployeeId = 3, Status = Enums.RequestStatus.Rejected, RequestDate = new DateTime(2025, 01, 10), ResponseDate = new DateTime(2025, 01, 10) }
            );

            modelBuilder.Entity<RequestedDay>().HasData(
                new RequestedDay { Id = 1, LeaveDay = new DateTime(2025, 2, 1), LeaveRequestId = 1, Year = 2025 },
                new RequestedDay { Id = 2, LeaveDay = new DateTime(2025, 2, 2), LeaveRequestId = 1, Year = 2025 },
                new RequestedDay { Id = 3, LeaveDay = new DateTime(2025, 2, 3), LeaveRequestId = 1, Year = 2025 },
                new RequestedDay { Id = 4, LeaveDay = new DateTime(2025, 2, 1), LeaveRequestId = 2, Year = 2025 },
                new RequestedDay { Id = 5, LeaveDay = new DateTime(2025, 2, 1), LeaveRequestId = 2, Year = 2025 },
                new RequestedDay { Id = 6, LeaveDay = new DateTime(2025, 2, 1), LeaveRequestId = 3, Year = 2025 }
            );


        }
    }
}
