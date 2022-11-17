using BusinessSolutions.OrderItemServices.BusinessLogic;
using BusinessSolutions.OrderItemServices.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessSolutions.OrderItemServices;

public static class Bootstrapper
{
    public static IServiceCollection AddOrderItemService(this IServiceCollection services)
    {
        services.AddTransient<IOrderItemService, OrderItemService>();

        services.AddAutoMapper(
            typeof(AddOrderItemModelProfile),
            typeof(OrderItemModelProfile),
            typeof(OrderItemProfile),
            typeof(UpdateOrderItemModelProfile)
            );

        return services;
    }
}
