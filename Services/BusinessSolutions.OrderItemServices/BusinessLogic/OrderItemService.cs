﻿using BusinessSolutions.OrderItemServices.Models;

namespace BusinessSolutions.OrderItemServices.BusinessLogic;

public class OrderItemService : IOrderItemService
{
    public Task<OrderItemModel> AddOrder(OrderItemModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrderItemModel(int id)
    {
        throw new NotImplementedException();
    }

    public Task<OrderItemModel> GetOrderItem(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderItemModel>> GetOrderItem(int offset = 0, int limit = 1000)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrderItemModel(int id, UpdateOrderItemModel model)
    {
        throw new NotImplementedException();
    }
}
