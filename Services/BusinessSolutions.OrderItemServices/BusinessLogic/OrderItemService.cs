using AutoMapper;
using BusinessSolutions.Data.Context;
using BusinessSolutions.Data.Entities;
using BusinessSolutions.OrderItemServices.Models;
using Microsoft.EntityFrameworkCore;

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
        var orderItem = _mapper.Map<OrderItem>(model);
        await _dbContext.OrderItems.AddAsync(orderItem);
        _dbContext.SaveChanges();

        return _mapper.Map<OrderItemModel>(orderItem);
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

    public async Task UpdateOrderItemModel(int id, UpdateOrderItemModel model)
    {
        //updateOrderModelValidator.Check(model);

        var orderItems = await _dbContext.OrderItems.FirstOrDefaultAsync(x => x.Id == id);
        // ProcessException.ThrowIf(() => order is null, $"The order (id: {id}) was not found");
        orderItems = _mapper.Map(model, orderItems);

        _dbContext.OrderItems.Update(orderItems);
        _dbContext.SaveChanges();
    }
}
