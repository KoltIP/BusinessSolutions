using BusinessSolutions.OrderItemServices.BusinessLogic;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessSolutions.OrderItemServices;

public static class Bootstrapper
{
    public static IServiceCollection AddOrderItemService(this IServiceCollection services)
    {
        services.AddTransient<IOrderItemService, OrderItemService>();

        return services;
    }
}
