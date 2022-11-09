namespace BusinessSolutions.MVC.Models.OrderItem
{
    public class OrderItemsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int? OrderId { get; set; }
        public string Order { get; set; }
    }
}
