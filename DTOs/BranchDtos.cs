
namespace ShiftIQ.API.DTOs
{
    // البيانات التي سترجع عند عرض الفرع
    public class BranchResponseDto
    {
        public int BranchId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal GeofenceRadiusMeters { get; set; }
        public bool IsActive { get; set; }
    }

    // البيانات المطلوبة عند إضافة فرع
    public class CreateBranchDto
    {
        public int CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal GeofenceRadiusMeters { get; set; }
    }

    // البيانات المطلوبة عند تعديل فرع
    public class UpdateBranchDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal GeofenceRadiusMeters { get; set; }
        public bool IsActive { get; set; }
    }
}
