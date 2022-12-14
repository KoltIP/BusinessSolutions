using AutoMapper;
using BusinessSolution.Shared.Exceptions;
using BusinessSolutions.Data.Context;
using BusinessSolutions.Data.Entities;
using BusinessSolutions.OrderServices.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BusinessSolutions.OrderServices.BusinessLogic;

public class OrderService : IOrderService
{

    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _dbContext;

    public OrderService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    public async Task<OrderModel> AddOrder(AddOrderModel model)
    {
        AddOrderModelValidator validationRules = new AddOrderModelValidator();
        var result = validationRules.Validate(model);
        if (!result.IsValid)
            throw new FluentValidation.ValidationException(result.Errors);

        var order = _mapper.Map<Order>(model);
        order.Date = order.Date.Date.AddDays(1);

        var check = _dbContext.Orders.FirstOrDefault(x => (x.Number == order.Number && x.ProviderId == order.ProviderId));
        if (check != null)
            throw new Exception("Ограничение предметная область");

        await _dbContext.Orders.AddAsync(order);
        _dbContext.SaveChanges();

        return _mapper.Map<OrderModel>(order);
    }

    public async Task DeleteOrder(int id)
    {
        var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id.Equals(id))
            ?? throw new ProcessException($"The order (id: {id}) was not found");

        _dbContext.Orders.Remove(order);
        _dbContext.SaveChanges();
    }

    public async Task<IEnumerable<OrderModel>> FilterOrders(int providerId, string startDate, string endDate)
    {
        var SD = Convert.ToDateTime(startDate);
        var ED = Convert.ToDateTime(endDate);

        IQueryable<Order> orders = _dbContext.Orders.AsQueryable();

        orders = orders
            .Include(x => x.Provider)
            .Where(x => (x.ProviderId == providerId));

        IEnumerable<Order> list = orders.ToList<Order>();
        list = list
            .Where(x => (x.Date >= SD))
            .Where(x => (x.Date <= ED));

        var data = list.Select(order => _mapper.Map<OrderModel>(order));
        return data;
    }

    public async Task<OrderModel> GetOrder(int id)
    {
        var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id.Equals(id));
        
        var data = _mapper.Map<OrderModel>(order);

        return data;
    }

    public async Task<IEnumerable<OrderModel>> GetOrders(int offset = 0, int limit = 1000)
    {
        var orders = _dbContext.Orders.AsQueryable();
        orders = orders
                    .Include(x => x.Provider)                        
                    .Skip(Math.Max(offset, 0))
                    .Take(Math.Max(0, Math.Min(limit, 1000)));

        var data = (await orders.ToListAsync()).Select(order => _mapper.Map<OrderModel>(order));
        return data;
    }

    public async Task UpdateOrder(int id, UpdateOrderModel model)
    {
        UpdateOrderModelValidator validationRules = new UpdateOrderModelValidator();
        var result = validationRules.Validate(model);
        if (!result.IsValid)
            throw new FluentValidation.ValidationException(result.Errors);

        var order =_dbContext.Orders.FirstOrDefault(x => x.Id.Equals(id));
        ProcessException.ThrowIf(() => order is null, $"The order (id: {id}) was not found");

        var check = _dbContext.Orders.FirstOrDefault(x => (x.Number == order.Number && x.ProviderId == order.ProviderId && x.Id!=order.Id));
        if (check != null)
            throw new Exception("Ограничение предметная область");

        order = _mapper.Map(model, order);

        _dbContext.Orders.Update(order);
        _dbContext.SaveChanges();
        
    }
}
