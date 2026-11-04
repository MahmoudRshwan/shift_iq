
using ShiftIQ.API.DTOs;

namespace ShiftIQ.API.Services
{
    public class DepartmentService
    {
        // Temporary Mock Data
        private static readonly List<DepartmentResponseDto> departments = new()
        {
            new DepartmentResponseDto
            {
                DepartmentId = 1,
                BranchId = 1,
                Name = "Human Resources"
            },
            new DepartmentResponseDto
            {
                DepartmentId = 2,
                BranchId = 1,
                Name = "Information Technology"
            },
            new DepartmentResponseDto
            {
                DepartmentId = 3,
                BranchId = 2,
                Name = "Finance"
            }
        };

        // Get all departments
        public List<DepartmentResponseDto> GetAll()
        {
            return departments;
        }

        // Get department by ID
        public DepartmentResponseDto? GetById(int id)
        {
            return departments.FirstOrDefault(d => d.DepartmentId == id);
        }

        // Create department
        public DepartmentResponseDto Create(CreateDepartmentDto dto)
        {
            var department = new DepartmentResponseDto
            {
                DepartmentId = departments.Count == 0
                    ? 1
                    : departments.Max(d => d.DepartmentId) + 1,

                BranchId = dto.BranchId,
                Name = dto.Name
            };

            departments.Add(department);

            return department;
        }

        // Update department
        public bool Update(int id, UpdateDepartmentDto dto)
        {
            var department = GetById(id);

            if (department == null)
                return false;

            department.Name = dto.Name;

            return true;
        }

        // Delete department
        public bool Delete(int id)
        {
            var department = GetById(id);

            if (department == null)
                return false;

            departments.Remove(department);

            return true;
        }
    }
}
