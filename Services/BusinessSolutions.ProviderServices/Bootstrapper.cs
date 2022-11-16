using BusinessSolutions.ProviderServices.BusinessLogic;
using BusinessSolutions.ProviderServices.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessSolutions.ProviderServices;

public static class Bootstrapper
{
    public static IServiceCollection AddProviderService(this IServiceCollection services)
    {
        services.AddTransient<IProviderService, ProviderService>();


        services.AddAutoMapper(
            typeof(ProviderModelProfile),
            typeof(ProviderProfile),
            typeof(AddProviderModelProfile),
            typeof(UpdateProviderModelProfile)
            );

        return services;
    }
}
