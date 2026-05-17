using InClassAssignMent.Models.Customars;

namespace InClassAssignMent.Models.Vehicles
{
    public class Vehicles
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }

        public int CustomarId { get; set; }
        public Customar Customar { get; set; } = null!;

        public ICollection<VehicleServiceType.VehicleServiceType> VehicleServiceTypes { get; set; } = new List<VehicleServiceType.VehicleServiceType>();
    }
}
