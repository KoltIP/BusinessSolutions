using BusinessSolutions.OrderItemServices.Models;

namespace BusinessSolutions.OrderItemServices.BusinessLogic;

public interface IOrderItemService
{
    Task<OrderItemModel> GetOrderItem(int id);
    Task<IEnumerable<OrderItemModel>> GetOrderItems(int offset = 0, int limit = 1000);
    Task<OrderItemModel> AddOrderItem(AddOrderItemModel model);
    Task UpdateOrderItemModel(int id, UpdateOrderItemModel model);
    Task DeleteOrderItemModel(int id);
}
