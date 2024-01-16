using Microsoft.Extensions.DependencyInjection;
using Play.Core;
using Play.Core.Domain;

namespace Play.Persistence;

public static class DependencyConfig
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
        services.AddSingleton<IRepository<Device, string>>(_ => {
            var deviceRepo = new InMemoryRepository<Device, string>();
            deviceRepo.Init(new Dictionary<string, Device>() {
                { "device-1", new Device("device-101", 101) },
                { "device-2", new Device("device-102", 102) },
                { "device-3", new Device("device-103", 103) },
            });
            return deviceRepo;
        });
        
        services.AddSingleton<IRepository<Connection, string>>(
            new InMemoryRepository<Connection, string>());
        
        return services;
    }
}