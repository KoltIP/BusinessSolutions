using BusinessSolutions.ProviderServices.BusinessLogic;
using BusinessSolutions.ProviderServices.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessSolutions.ProviderServices
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddProviderService(this IServiceCollection services)
        {
            services.AddTransient<IProviderService, ProviderService>();


            services.AddAutoMapper(
                typeof(ProviderModelProfile),
                typeof(ProviderProfile)
                //typeof(AddProviderModelProfile),
                //typeof(ProviderOrderModelProfile)
                );

            return services;
        }
    }
}
