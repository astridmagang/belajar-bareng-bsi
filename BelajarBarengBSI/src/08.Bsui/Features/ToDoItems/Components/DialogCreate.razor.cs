using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Zeta.BelajarBarengBSI.Base.TodoItems.Enums;
using Zeta.BelajarBarengBSI.Bsui.Common.Extensions;
using Zeta.BelajarBarengBSI.Shared.Common.Responses;
using Zeta.BelajarBarengBSI.Shared.ToDoItems.Commands.CreateToDoItem;
using Zeta.BelajarBarengBSI.Shared.ToDoItems.Constants;

namespace Zeta.BelajarBarengBSI.Bsui.Features.ToDoItems.Components;

public partial class DialogCreate
{
    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; } = default!;

    [Parameter]
    public Guid ToDoGroupId { get; set; }

    private CreateToDoItemRequest _request = default!;
    private bool _isLoading;
    private ErrorResponse? _error;

    protected override void OnParametersSet()
    {
        _request = new CreateToDoItemRequest
        {
            ToDoGroupId = ToDoGroupId,
            Title = $"{DisplayTextFor.ToDoItem} {DisplayTextFor.Title}",
            PriorityLevel = PriorityLevel.None,
            Description = $"{DisplayTextFor.ToDoItem} {DisplayTextFor.Description}"
        };
    }

    private void Cancel()
    {
        MudDialog.Cancel();
    }

    private async Task OnValidSubmit()
    {
        _error = null;

        _isLoading = true;

        var response = await _toDoItemService.CreateToDoItemAsync(_request);

        _isLoading = false;

        if (response.Error is not null)
        {
            _error = response.Error;

            return;
        }

        MudDialog.Close(DialogResult.Ok(response.Result!.ToDoItemId));
    }

    private void OnInvalidSubmit(EditContext editContext)
    {
        _snackbar.AddErrors(editContext.GetValidationMessages());
    }
}
