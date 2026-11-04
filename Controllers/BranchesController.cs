
using Microsoft.AspNetCore.Mvc;
using ShiftIQ.API.DTOs;
using ShiftIQ.API.Services;

namespace ShiftIQ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchesController : ControllerBase
    {
        private readonly BranchService _branchService;

        public BranchesController(BranchService branchService)
        {
            _branchService = branchService;
        }

        // GET: api/branches
        [HttpGet]
        public ActionResult<List<BranchResponseDto>> GetAll()
        {
            return Ok(_branchService.GetAll());
        }

        // GET: api/branches/1
        [HttpGet("{id}")]
        public ActionResult<BranchResponseDto> GetById(int id)
        {
            var branch = _branchService.GetById(id);

            if (branch == null)
                return NotFound("Branch not found.");

            return Ok(branch);
        }

        // POST: api/branches
        [HttpPost]
        public ActionResult<BranchResponseDto> Create(
            [FromBody] CreateBranchDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest("Branch name is required.");

            if (dto.CompanyId <= 0)
                return BadRequest("Valid CompanyId is required.");

            if (dto.Latitude < -90 || dto.Latitude > 90 ||
                dto.Longitude < -180 || dto.Longitude > 180)
                return BadRequest("Invalid coordinates.");

            if (dto.GeofenceRadiusMeters <= 0)
                return BadRequest("Geofence radius must be greater than zero.");

            var branch = _branchService.Create(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = branch.BranchId },
                branch
            );
        }

        // PUT: api/branches/1
        [HttpPut("{id}")]
        public IActionResult Update(
            int id,
            [FromBody] UpdateBranchDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest("Branch name is required.");

            if (dto.Latitude < -90 || dto.Latitude > 90 ||
                dto.Longitude < -180 || dto.Longitude > 180)
                return BadRequest("Invalid coordinates.");

            if (dto.GeofenceRadiusMeters <= 0)
                return BadRequest("Geofence radius must be greater than zero.");

            var updated = _branchService.Update(id, dto);

            if (!updated)
                return NotFound("Branch not found.");

            return NoContent();
        }

        // DELETE: api/branches/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _branchService.Delete(id);

            if (!deleted)
                return NotFound("Branch not found.");

            return NoContent();
        }
    }
}
