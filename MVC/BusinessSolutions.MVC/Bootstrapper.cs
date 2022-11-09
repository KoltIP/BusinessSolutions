using BusinessSolutions.OrderItemServices;
using BusinessSolutions.OrderServices;
using BusinessSolutions.ProviderServices;

namespace BusinessSolutions.MVC
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddOrderService();
            services.AddOrderItemService();
            services.AddProviderService();
            return services;
        }
    }
}
