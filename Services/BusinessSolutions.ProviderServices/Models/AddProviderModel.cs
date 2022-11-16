using AutoMapper;
using BusinessSolutions.Data.Entities;

namespace BusinessSolutions.ProviderServices.Models;

public class AddProviderModel
{ 
    public string Name { get; set; } = string.Empty;
}

public class AddProviderModelProfile : Profile
{
    public AddProviderModelProfile()
    {
        CreateMap<AddProviderModel, Provider>();
    }
}

