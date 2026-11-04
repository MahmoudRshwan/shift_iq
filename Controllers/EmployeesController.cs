
using Microsoft.AspNetCore.Mvc;
using ShiftIQ.API.DTOs;
using ShiftIQ.API.Services;

namespace ShiftIQ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/employees
        [HttpGet]
        public ActionResult<List<EmployeeResponseDto>> GetAll()
        {
            return Ok(_employeeService.GetAll());
        }

        // GET: api/employees/1
        [HttpGet("{id}")]
        public ActionResult<EmployeeResponseDto> GetById(int id)
        {
            var employee = _employeeService.GetById(id);

            if (employee == null)
                return NotFound("Employee not found.");

            return Ok(employee);
        }

        // POST: api/employees
        [HttpPost]
        public ActionResult<EmployeeResponseDto> Create(
            [FromBody] CreateEmployeeDto dto)
        {
            if (dto.DepartmentId <= 0 || dto.UserId <= 0)
                return BadRequest("Valid DepartmentId and UserId are required.");

            if (string.IsNullOrWhiteSpace(dto.EmployeeNumber))
                return BadRequest("Employee number is required.");

            if (string.IsNullOrWhiteSpace(dto.JobTitle))
                return BadRequest("Job title is required.");

            if (dto.HiredOn == default)
                return BadRequest("Valid hiring date is required.");

            var employee = _employeeService.Create(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = employee.EmployeeId },
                employee
            );
        }

        // PUT: api/employees/1
        [HttpPut("{id}")]
        public IActionResult Update(
            int id,
            [FromBody] UpdateEmployeeDto dto)
        {
            if (dto.DepartmentId <= 0)
                return BadRequest("Valid DepartmentId is required.");

            if (string.IsNullOrWhiteSpace(dto.EmployeeNumber))
                return BadRequest("Employee number is required.");

            if (string.IsNullOrWhiteSpace(dto.JobTitle))
                return BadRequest("Job title is required.");

            if (string.IsNullOrWhiteSpace(dto.Status))
                return BadRequest("Employee status is required.");

            if (dto.HiredOn == default)
                return BadRequest("Valid hiring date is required.");

            var updated = _employeeService.Update(id, dto);

            if (!updated)
                return NotFound("Employee not found.");

            return NoContent();
        }

        // DELETE: api/employees/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _employeeService.Delete(id);

            if (!deleted)
                return NotFound("Employee not found.");

            return NoContent();
        }
    }
}
