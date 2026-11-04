
using ShiftIQ.API.DTOs;

namespace ShiftIQ.API.Services
{
    public class BranchService
    {
        // Temporary Mock Data
        private static readonly List<BranchResponseDto> branches = new()
        {
            new BranchResponseDto
            {
                BranchId = 1,
                CompanyId = 1,
                Name = "Main Branch",
                Latitude = 27.1809m,
                Longitude = 31.1837m,
                GeofenceRadiusMeters = 100,
                IsActive = true
            },
            new BranchResponseDto
            {
                BranchId = 2,
                CompanyId = 1,
                Name = "Second Branch",
                Latitude = 27.1900m,
                Longitude = 31.1900m,
                GeofenceRadiusMeters = 150,
                IsActive = true
            }
        };

        // Get all branches
        public List<BranchResponseDto> GetAll()
        {
            return branches;
        }

        // Get branch by ID
        public BranchResponseDto? GetById(int id)
        {
            return branches.FirstOrDefault(b => b.BranchId == id);
        }

        // Create branch
        public BranchResponseDto Create(CreateBranchDto dto)
        {
            var branch = new BranchResponseDto
            {
                BranchId = branches.Count == 0
                    ? 1
                    : branches.Max(b => b.BranchId) + 1,

                CompanyId = dto.CompanyId,
                Name = dto.Name,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                GeofenceRadiusMeters = dto.GeofenceRadiusMeters,
                IsActive = true
            };

            branches.Add(branch);

            return branch;
        }

        // Update branch
        public bool Update(int id, UpdateBranchDto dto)
        {
            var branch = GetById(id);

            if (branch == null)
                return false;

            branch.Name = dto.Name;
            branch.Latitude = dto.Latitude;
            branch.Longitude = dto.Longitude;
            branch.GeofenceRadiusMeters = dto.GeofenceRadiusMeters;
            branch.IsActive = dto.IsActive;

            return true;
        }

        // Delete branch
        public bool Delete(int id)
        {
            var branch = GetById(id);

            if (branch == null)
                return false;

            branches.Remove(branch);

            return true;
        }
    }
}
