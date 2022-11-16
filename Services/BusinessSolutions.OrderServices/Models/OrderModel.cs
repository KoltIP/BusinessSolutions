using AutoMapper;
using BusinessSolutions.Data.Entities;

namespace BusinessSolutions.OrderServices.Models;

public class OrderModel
{
    public int Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public DateTime Date { get; set; }        
    public int ProviderId { get; set; }
    public string ProviderName { get; set; } = string.Empty;
}

public class OrderModelProfile : Profile
{
    public OrderModelProfile()
    {
        CreateMap<Order, OrderModel>()
            .ForMember(dest => dest.ProviderName, opt => opt.MapFrom(src => src.Provider.Name));
    }
}

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<OrderModel,Order>();
    }
}

