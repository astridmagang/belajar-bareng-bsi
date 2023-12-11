using MudBlazor;
using Zeta.BelajarBarengBSI.Bsui.Common.Constants;
using Zeta.BelajarBarengBSI.Shared.Common.Constants;
using Zeta.BelajarBarengBSI.Shared.Common.Extensions;

namespace Zeta.BelajarBarengBSI.Bsui.Common.Pages;

public partial class Index
{
    private List<BreadcrumbItem> _breadcrumbItems = new();
    private string _greetings = default!;

    protected override void OnInitialized()
    {
        SetupBreadcrumb();

        _greetings = $"Good {DateTimeOffset.Now.ToFriendlyTimeDisplayText()}";
    }

    private void SetupBreadcrumb()
    {
        _breadcrumbItems = new()
        {
            CommonBreadcrumbFor.Active(CommonDisplayTextFor.Home)
        };
    }
}
