using AutoMapper;
using BusinessSolutions.ProviderServices.Models;

namespace BusinessSolutions.MVC.Models.Provider;

public class AddProviderRequest
{
    public string Name { get; set; } = string.Empty;
}

public class AddProviderRequestProfile : Profile
{
    public AddProviderRequestProfile()
    {
        CreateMap<AddProviderRequest, AddProviderModel>();
    }
}
