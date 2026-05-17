namespace InClassAssignMent.Models.DTOs
{
    public class CustomarCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }

    public class VehicleCreateDto
    {
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public int CustomarId { get; set; }
    }

    public class ServiceTypeCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Cost { get; set; }
    }

    public class VehicleServiceTypeCreateDto
    {
        public int VehicleId { get; set; }
        public int ServiceTypeId { get; set; }
        public DateTime ServiceDate { get; set; }
    }
}
