using AutoMapper;
using BusinessSolutions.Data.Entities;
using BusinessSolutions.MVC.Models.OrderItem;
using BusinessSolutions.OrderServices.Models;

namespace BusinessSolutions.MVC.Models.Order
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string ProviderName { get; set; } = string.Empty;
        public List<OrderItemResponse> Content {get;set;}
    }

    public class OrderResponseProfile : Profile
    {
        public OrderResponseProfile()
        {
            CreateMap<OrderModel, OrderResponse>();
        }
    }

}
