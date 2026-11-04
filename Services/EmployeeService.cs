
using ShiftIQ.API.DTOs;

namespace ShiftIQ.API.Services
{
    public class EmployeeService
    {
        // Temporary Mock Data
        private static readonly List<EmployeeResponseDto> employees = new()
        {
            new EmployeeResponseDto
            {
                EmployeeId = 1,
                DepartmentId = 1,
                UserId = 1,
                EmployeeNumber = "EMP-001",
                JobTitle = "HR Specialist",
                Status = "Active",
                HiredOn = new DateTime(2025, 1, 15)
            },
            new EmployeeResponseDto
            {
                EmployeeId = 2,
                DepartmentId = 2,
                UserId = 2,
                EmployeeNumber = "EMP-002",
                JobTitle = "Software Developer",
                Status = "Active",
                HiredOn = new DateTime(2025, 3, 1)
            },
            new EmployeeResponseDto
            {
                EmployeeId = 3,
                DepartmentId = 3,
                UserId = 3,
                EmployeeNumber = "EMP-003",
                JobTitle = "Accountant",
                Status = "Active",
                HiredOn = new DateTime(2025, 5, 10)
            }
        };

        public List<EmployeeResponseDto> GetAll()
        {
            return employees;
        }

        public EmployeeResponseDto? GetById(int id)
        {
            return employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public EmployeeResponseDto Create(CreateEmployeeDto dto)
        {
            var employee = new EmployeeResponseDto
            {
                EmployeeId = employees.Count == 0
                    ? 1
                    : employees.Max(e => e.EmployeeId) + 1,
                DepartmentId = dto.DepartmentId,
                UserId = dto.UserId,
                EmployeeNumber = dto.EmployeeNumber,
                JobTitle = dto.JobTitle,
                Status = dto.Status,
                HiredOn = dto.HiredOn
            };

            employees.Add(employee);
            return employee;
        }

        public bool Update(int id, UpdateEmployeeDto dto)
        {
            var employee = GetById(id);
            if (employee == null) return false;

            employee.DepartmentId = dto.DepartmentId;
            employee.EmployeeNumber = dto.EmployeeNumber;
            employee.JobTitle = dto.JobTitle;
            employee.Status = dto.Status;
            employee.HiredOn = dto.HiredOn;

            return true;
        }

        public bool Delete(int id)
        {
            var employee = GetById(id);
            if (employee == null) return false;

            employees.Remove(employee);
            return true;
        }
    }
}
