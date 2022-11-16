using AutoMapper;
using BusinessSolutions.Data.Entities;

namespace BusinessSolutions.ProviderServices.Models;

public class UpdateProviderModel
{
    public string Name { get; set; } = string.Empty;
}

public class UpdateProviderModelProfile : Profile
{
    public UpdateProviderModelProfile()
    {
        CreateMap<UpdateProviderModel, Provider>();
    }
}

