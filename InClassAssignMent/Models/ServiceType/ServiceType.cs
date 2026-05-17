namespace InClassAssignMent.Models.ServiceType
{
    public class ServiceType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Cost { get; set; }

        public ICollection<VehicleServiceType.VehicleServiceType> VehicleServiceTypes { get; set; } = new List<VehicleServiceType.VehicleServiceType>();
    }
}
