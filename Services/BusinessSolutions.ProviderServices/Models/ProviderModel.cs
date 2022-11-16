using AutoMapper;
using BusinessSolutions.Data.Entities;

namespace BusinessSolutions.ProviderServices.Models;

public class ProviderModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class ProviderModelProfile : Profile
{
    public ProviderModelProfile()
    {
        CreateMap<Provider, ProviderModel>();
    }
}

public class ProviderProfile : Profile
{
    public ProviderProfile()
    {
        CreateMap<ProviderModel, Provider>();
    }
}
