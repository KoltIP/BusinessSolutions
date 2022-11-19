using BusinessSolutions.MVC.Models.Order;
using BusinessSolutions.MVC.Models.OrderItem;
using BusinessSolutions.MVC.Models.Provider;

namespace BusinessSolutions.MVC.Configuration.AutoMapperConfiguration;

public static class MapperConfiguration
{
    public static IServiceCollection AddAppAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(AddOrderRequestProfile),
            typeof(OrderResponseProfile),
            typeof(UpdateOrderRequestProfile),
            typeof(AddOrderItemRequestProfile),
            typeof(OrderItemResponseProfile),
            typeof(ProviderResponseProfile),
            typeof(AddProviderRequestProfile),
            typeof(UpdateProviderRequestProfile));
        return services;
    }
}
