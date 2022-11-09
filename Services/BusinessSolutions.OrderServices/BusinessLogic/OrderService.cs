using AutoMapper;
using BusinessSolutions.Data.Context;
using BusinessSolutions.Data.Entities;
using BusinessSolutions.OrderServices.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessSolutions.OrderServices.BusinessLogic
{
    public class OrderService : IOrderService
    {

        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        //private readonly IModelValidator<AddOrderModel> addOrderModelValidator;
        //private readonly IModelValidator<UpdateOrderModel> updateOrderModelValidator;
        
        public OrderService(ApplicationDbContext dbContext, IMapper _mapper)
            //IModelValidator<AddOrderModel> addOrderModelValidator,
            //IModelValidator<UpdateOrderModel> updateOrderModelValidator)
        {
            _dbContext = dbContext;
            _mapper = _mapper;
            //this.addOrderModelValidator = addOrderModelValidator;
            //this.updateOrderModelValidator = updateOrderModelValidator;
        }


        public async Task<OrderModel> AddOrder(AddOrderModel model)
        {
            //addOrderModelValidator.Check(model);

            var order = _mapper.Map<Order>(model);
            await _dbContext.Orders.AddAsync(order);
            _dbContext.SaveChanges();

            return _mapper.Map<OrderModel>(order);
        }

        public async Task DeleteOrder(int id)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id.Equals(id))
                ;//?? throw new ProcessException($"The order (id: {id}) was not found");

            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }

        public async Task<OrderModel> GetOrder(int id)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id.Equals(id));

            var data = _mapper.Map<OrderModel>(order);

            return data;
        }

        public async Task<IEnumerable<OrderModel>> GetOrders(int offset = 0, int limit = 1000)
        {
            var order = _dbContext.Orders.AsQueryable();
            order = order
                        .Skip(Math.Max(offset, 0))
                        .Take(Math.Max(0, Math.Min(limit, 1000)));

            var data = (await order.ToListAsync()).Select(order => _mapper.Map<OrderModel>(order));
            return data;
        }

        public async Task UpdateOrder(int id, UpdateOrderModel model)
        {
            //updateOrderModelValidator.Check(model);

            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id.Equals(id));
            ;// ProcessException.ThrowIf(() => order is null, $"The order (id: {id}) was not found");

            order = _mapper.Map(model, order);

            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }
    }
}
