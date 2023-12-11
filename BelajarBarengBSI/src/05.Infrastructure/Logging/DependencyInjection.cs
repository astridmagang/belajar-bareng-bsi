using Microsoft.Extensions.Hosting;
using Zeta.BelajarBarengBSI.Infrastructure.Logging.Serilog;

namespace Zeta.BelajarBarengBSI.Infrastructure.Logging;

public static class DependencyInjection
{
    public static IHostBuilder UseLoggingService(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilogLoggingService();

        return hostBuilder;
    }
}
