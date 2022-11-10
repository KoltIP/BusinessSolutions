using BusinessSolutions.OrderServices.BusinessLogic;
using BusinessSolutions.OrderServices.Models;
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
}
