using AutoMapper;
using BusinessSolutions.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessSolutions.OrderServices.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
    }

    public class OrderModelProfile : Profile
    {
        public OrderModelProfile()
        {
            CreateMap<Order, OrderModel>();
        }
    }

    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderModel,Order>();
        }
    }

}
