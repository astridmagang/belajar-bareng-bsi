using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zeta.BelajarBarengBSI.Infrastructure.AppInfo;
using Zeta.BelajarBarengBSI.Infrastructure.DateAndTime;
using Zeta.BelajarBarengBSI.Infrastructure.Persistence;

namespace Zeta.BelajarBarengBSI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAppInfoService(configuration);
        services.AddDateAndTimeService();
        services.AddPersistenceService(configuration);

        return services;
    }
}
