using Zeta.BelajarBarengBSI.Bsui.Services.UI.MudBlazorUI;

namespace Zeta.BelajarBarengBSI.Bsui.Services.UI;

public static class DependencyInjection
{
    public static IServiceCollection AddUIService(this IServiceCollection services)
    {
        services.AddMudBlazorUIService();

        return services;
    }
}
