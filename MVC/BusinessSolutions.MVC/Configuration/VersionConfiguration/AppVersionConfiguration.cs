using Microsoft.AspNetCore.Mvc;

namespace BusinessSolutions.MVC.Configuration.VersionConfiguration;

public static class AppVersionConfiguration
{
    public static IServiceCollection AddAppVersion(this IServiceCollection services)
    {
        return services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
        });
    }
}
