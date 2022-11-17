﻿using AutoMapper;
using BusinessSolutions.Data.Entities;

namespace BusinessSolutions.OrderItemServices.Models;

public class UpdateOrderItemModel
{
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;
    public int OrderId { get; set; }
}

public class UpdateOrderItemModelProfile : Profile
{
    public UpdateOrderItemModelProfile()
    {
        CreateMap<UpdateOrderItemModel, OrderItem>();
    }
}
