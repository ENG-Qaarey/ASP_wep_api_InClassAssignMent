namespace InClassAssignMent.Models.Customars
{
    public class Customar
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public ICollection<Vehicles.Vehicles> Vehicles { get; set; } = new List<Vehicles.Vehicles>();
    }
}
