using AutoMapper;
using AutoMapper.Configuration.Conventions;
using BusinessSolutions.Data.Context;
using BusinessSolutions.Data.Entities;
using BusinessSolutions.OrderItemServices.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BusinessSolutions.OrderItemServices.BusinessLogic;

public class OrderItemService : IOrderItemService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _dbContext;

    public OrderItemService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<OrderItemModel> AddOrderItem(AddOrderItemModel model)
    {
        AddOrderItemModelValidator validationRules = new AddOrderItemModelValidator();
        var result = validationRules.Validate(model);
        if (!result.IsValid)
            throw new Exception("Невалидный");

        var orderItem = _mapper.Map<OrderItem>(model);
        await _dbContext.OrderItems.AddAsync(orderItem);
        _dbContext.SaveChanges();

        return _mapper.Map<OrderItemModel>(orderItem);
    }

    public async Task AddOrUpdateOrderItem(IEnumerable<AddOrUpdateOrderItemModel> models)
    {
        _dbContext.OrderItems.RemoveRange(_dbContext.OrderItems.Where(x => x.OrderId == models.Last().OrderId));
        _dbContext.SaveChanges();
        foreach (var model in models)
        {
            AddOrUpdateOrderItemModelValidator validationRules = new AddOrUpdateOrderItemModelValidator();
            var result = validationRules.Validate(model);
            if (!result.IsValid)
                throw new Exception("Невалидный");

            var order = _dbContext.Orders.FirstOrDefault(x => x.Id == model.OrderId);

            if (order.Number == model.Name)
                throw new Exception("Предметная область");

            var entity = _dbContext.OrderItems.FirstOrDefaultAsync(x => x.Id == model.Id).Result;
            if (entity == null)
            {
                var orderItem = _mapper.Map<OrderItem>(model);
                await _dbContext.OrderItems.AddAsync(orderItem);
                _dbContext.SaveChanges();
            }
            else
            {
                entity = _mapper.Map(model, entity);

                _dbContext.OrderItems.Update(entity);
                _dbContext.SaveChanges();
            }
        }
    }

    public async Task DeleteOrderItemModel(int id)
    {
        var orderItem = await _dbContext.OrderItems.FirstOrDefaultAsync(x => x.Id.Equals(id))
            ;//?? throw new ProcessException($"The order (id: {id}) was not found");

        _dbContext.OrderItems.Remove(orderItem);
        _dbContext.SaveChanges();
    }

    public async Task<OrderItemModel> GetOrderItem(int id)
    {
        var orderItem = await _dbContext.OrderItems.FirstOrDefaultAsync(x => x.Id.Equals(id));

        var data = _mapper.Map<OrderItemModel>(orderItem);

        return data;
    }

    public async Task<IEnumerable<OrderItemModel>> GetOrderItems(int offset = 0, int limit = 1000)
    {
        var orderItems = _dbContext.OrderItems.AsQueryable();
        orderItems = orderItems
                    .Skip(Math.Max(offset, 0))
                    .Take(Math.Max(0, Math.Min(limit, 1000)));

        var data = (await orderItems.ToListAsync()).Select(order => _mapper.Map<OrderItemModel>(order));
        return data;
    }

    public async Task<IEnumerable<OrderItemModel>> GetOrderItemsByOrderId(int orderId)
    {
        var orderItems = _dbContext.OrderItems.AsQueryable();
        orderItems = orderItems.Where(x => x.OrderId.Equals(orderId));

        var data = (await orderItems.ToListAsync()).Select(order => _mapper.Map<OrderItemModel>(order));
        return data;
    }

}
