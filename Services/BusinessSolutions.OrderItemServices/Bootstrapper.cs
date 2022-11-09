using BusinessSolutions.OrderItemServices.BusinessLogic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessSolutions.OrderItemServices
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddOrderItemService(this IServiceCollection services)
        {
            services.AddTransient<IOrderItemService, OrderItemService>();

            return services;
        }
    }
}
