using BusinessSolutions.OrderServices.BusinessLogic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessSolutions.OrderServices
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddOrderService(this IServiceCollection services)
        {
            services.AddSingleton<IOrderService, OrderService>();


            return services;
        }
    }
}
