using Microsoft.Extensions.DependencyInjection;
using Zeta.BelajarBarengBSI.Application.Services.DateAndTime;

namespace Zeta.BelajarBarengBSI.Infrastructure.DateAndTime;

public static class DependencyInjection
{
    public static IServiceCollection AddDateAndTimeService(this IServiceCollection services)
    {
        services.AddTransient<IDateAndTimeService, DateAndTimeService>();

        return services;
    }
}
