using System;
using Lithium.Configuration.Infrastructure.Data;
using Lithium.Configuration.Core.Interfaces;

namespace Lithium.Configuration;

public static class ServiceRegistry
{
    public static IServiceCollection AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseEntityAsyncRepository<,>), typeof(BaseEntityEfRepository<,>));
        return services;
    }
}

