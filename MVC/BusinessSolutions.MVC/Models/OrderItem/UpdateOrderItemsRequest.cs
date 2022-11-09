namespace BusinessSolutions.MVC.Models.OrderItem
{
    public class UpdateOrderItemsRequest
    {
        public string Name { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int? OrderId { get; set; }
    }
}
