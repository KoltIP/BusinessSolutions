using AutoMapper;
using BusinessSolutions.Data.Entities;

namespace BusinessSolutions.OrderItemServices.Models;

public class OrderItemModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;
    public int OrderId { get; set; }
}


public class OrderItemModelProfile : Profile
{
    public OrderItemModelProfile()
    {
        CreateMap<OrderItem,OrderItemModel>();
    }
}

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<OrderItemModel, OrderItem>();
    }
}