namespace InClassAssignMent.Models.VehicleServiceType
{
    public class VehicleServiceType
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicles.Vehicles Vehicle { get; set; } = null!;

        public int ServiceTypeId { get; set; }
        public ServiceType.ServiceType ServiceType { get; set; } = null!;

        public DateTime ServiceDate { get; set; }
    }
}
