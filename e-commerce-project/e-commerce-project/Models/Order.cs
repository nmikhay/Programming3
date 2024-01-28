namespace e_commerce_project.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string customerName { get; set; }
        public string customerAddress { get; set; }

    }
}
