using BusinessSolutions.OrderServices;

namespace BusinessSolutions.MVC
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddOrderService();
            return services;
        }
    }
}
