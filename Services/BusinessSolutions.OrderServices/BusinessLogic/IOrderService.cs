using BusinessSolutions.OrderServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessSolutions.OrderServices.BusinessLogic
{
    public interface IOrderService
    {
        Task<OrderModel> GetOrder(int id);
        Task<IEnumerable<OrderModel>> GetOrders(int offset = 0, int limit = 1000);
        Task<OrderModel> AddOrder(AddOrderModel model);
        Task UpdateOrder(int id, UpdateOrderModel model);
        Task DeleteOrder(int id);
        Task<IEnumerable<OrderModel>> FilterOrders(int providerId, string startDate, string endDate);
    }
}
