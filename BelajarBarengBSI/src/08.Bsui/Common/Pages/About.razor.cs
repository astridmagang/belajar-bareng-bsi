using MudBlazor;
using Zeta.BelajarBarengBSI.Bsui.Common.Constants;
using Zeta.BelajarBarengBSI.Shared.Common.Constants;

namespace Zeta.BelajarBarengBSI.Bsui.Common.Pages;

public partial class About
{
    private List<BreadcrumbItem> _breadcrumbItems = new();

    protected override void OnInitialized()
    {
        SetupBreadcrumb();
    }

    private void SetupBreadcrumb()
    {
        _breadcrumbItems = new()
        {
            CommonBreadcrumbFor.Home,
            CommonBreadcrumbFor.Active(CommonDisplayTextFor.About)
        };
    }
}
