using Microsoft.Extensions.DependencyInjection;

namespace Play.Core;

public static class DependencyConfig
{
    public static IServiceCollection AddServices(
        this IServiceCollection services)
    {
        services.AddTransient<IPlayService, PlayService>();
        return services;
    }
    
}