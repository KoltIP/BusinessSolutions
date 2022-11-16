using AutoMapper;
using BusinessSolutions.ProviderServices.Models;

namespace BusinessSolutions.MVC.Models.Provider;

public class UpdateProviderRequest
{
    public string Name { get; set; } = string.Empty;
}

public class UpdateProviderRequestProfile : Profile
{
    public UpdateProviderRequestProfile()
    {
        CreateMap<UpdateProviderRequest, UpdateProviderModel>();
    }
}

