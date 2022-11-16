using BusinessSolutions.OrderServices.BusinessLogic;
using BusinessSolutions.OrderServices.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessSolutions.OrderServices;

public static class Bootstrapper
{
    public static IServiceCollection AddOrderService(this IServiceCollection services)
    {
        services.AddTransient<IOrderService, OrderService>();

        services.AddAutoMapper(
            typeof(AddOrderModelProfile),
            typeof(OrderModelProfile),
            typeof(OrderProfile),
            typeof(UpdateOrderModelProfile)
            );

        return services;
    }
}
