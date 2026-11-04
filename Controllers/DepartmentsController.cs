
using Microsoft.AspNetCore.Mvc;
using ShiftIQ.API.DTOs;
using ShiftIQ.API.Services;

namespace ShiftIQ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentsController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/departments
        [HttpGet]
        public ActionResult<List<DepartmentResponseDto>> GetAll()
        {
            return Ok(_departmentService.GetAll());
        }

        // GET: api/departments/1
        [HttpGet("{id}")]
        public ActionResult<DepartmentResponseDto> GetById(int id)
        {
            var department = _departmentService.GetById(id);

            if (department == null)
                return NotFound("Department not found.");

            return Ok(department);
        }

        // POST: api/departments
        [HttpPost]
        public ActionResult<DepartmentResponseDto> Create(
            [FromBody] CreateDepartmentDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest("Department name is required.");

            if (dto.BranchId <= 0)
                return BadRequest("Valid BranchId is required.");

            var department = _departmentService.Create(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = department.DepartmentId },
                department
            );
        }

        // PUT: api/departments/1
        [HttpPut("{id}")]
        public IActionResult Update(
            int id,
            [FromBody] UpdateDepartmentDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest("Department name is required.");

            var updated = _departmentService.Update(id, dto);

            if (!updated)
                return NotFound("Department not found.");

            return NoContent();
        }

        // DELETE: api/departments/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _departmentService.Delete(id);

            if (!deleted)
                return NotFound("Department not found.");

            return NoContent();
        }
    }
}
