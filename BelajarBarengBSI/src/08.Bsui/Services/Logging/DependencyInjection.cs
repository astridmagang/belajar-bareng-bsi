using Zeta.BelajarBarengBSI.Bsui.Services.Logging.Serilog;

namespace Zeta.BelajarBarengBSI.Bsui.Services.Logging;

public static class DependencyInjection
{
    public static IHostBuilder UseLoggingService(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilogLoggingService();

        return hostBuilder;
    }
}
