namespace TruckManagementSystem.Models
{
    public class Load
    {
        public int LoadId { get; set; }
        public string PickupLocation { get; set; }
        public string DeliveryLocation { get; set; }
        public DateTime Schedule { get; set; }
        public decimal Capacity { get; set; }
        public int DriverId { get; set; }
        public string PaymentDetails { get; set; }
        public decimal Amount { get; set; }

        public virtual Driver Driver { get; set; }
    }

}
