using BusinessSolutions.OrderItemServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessSolutions.OrderItemServices.BusinessLogic
{
    public interface IOrderItemService
    {
        Task<OrderItemModel> GetOrderItem(int id);
        Task<IEnumerable<OrderItemModel>> GetOrderItem(int offset = 0, int limit = 1000);
        Task<OrderItemModel> AddOrder(OrderItemModel model);
        Task UpdateOrderItemModel(int id, UpdateOrderItemModel model);
        Task DeleteOrderItemModel(int id);
    }
}
