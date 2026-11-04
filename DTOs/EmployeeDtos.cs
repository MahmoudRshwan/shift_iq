
namespace ShiftIQ.API.DTOs
{
    public class EmployeeResponseDto
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public int UserId { get; set; }
        public string EmployeeNumber { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime HiredOn { get; set; }
    }

    public class CreateEmployeeDto
    {
        public int DepartmentId { get; set; }
        public int UserId { get; set; }
        public string EmployeeNumber { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
        public DateTime HiredOn { get; set; }
    }

    public class UpdateEmployeeDto
    {
        public int DepartmentId { get; set; }
        public string EmployeeNumber { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime HiredOn { get; set; }
    }
}
