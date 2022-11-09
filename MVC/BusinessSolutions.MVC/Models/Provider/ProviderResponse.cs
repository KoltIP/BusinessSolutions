using AutoMapper;
using BusinessSolutions.MVC.Models.OrderItem;
using BusinessSolutions.OrderItemServices.Models;
using BusinessSolutions.ProviderServices.Models;

namespace BusinessSolutions.MVC.Models.Provider
{
    public class ProviderResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class ProviderResponseProfile : Profile
    {
        public ProviderResponseProfile()
        {
            CreateMap<ProviderModel, ProviderResponse>();
        }
    }
}
