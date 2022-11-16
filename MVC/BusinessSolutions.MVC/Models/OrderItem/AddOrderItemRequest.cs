using AutoMapper;
using BusinessSolutions.OrderItemServices.Models;

namespace BusinessSolutions.MVC.Models.OrderItem;

public class AddOrderItemRequest
{
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;
    public int? OrderId { get; set; }
}

public class AddOrderItemRequestProfile : Profile
{
    public AddOrderItemRequestProfile()
    {
        CreateMap<AddOrderItemRequest, AddOrderItemModel>();
    }
}
