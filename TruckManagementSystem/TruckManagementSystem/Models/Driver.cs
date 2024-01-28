namespace TruckManagementSystem.Models
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactDetails { get; set; }
        public string Preferences { get; set; }
        public decimal PayRate { get; set; }
        public int AssignedLoadId { get; set; }
    }

}
