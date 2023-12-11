using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zeta.BelajarBarengBSI.Application.Common.Exceptions;
using Zeta.BelajarBarengBSI.Application.ToDoGroups.Commands.CreateToDoGroup;
using Zeta.BelajarBarengBSI.Application.ToDoGroups.Commands.DeleteToDoGroup;
using Zeta.BelajarBarengBSI.Application.ToDoGroups.Commands.UpdateToDoGroup;
using Zeta.BelajarBarengBSI.Application.ToDoGroups.Queries.GetToDoGroup;
using Zeta.BelajarBarengBSI.Application.ToDoGroups.Queries.GetToDoGroups;
using Zeta.BelajarBarengBSI.Shared.Common.Responses;
using Zeta.BelajarBarengBSI.Shared.ToDoGroups.Commands.CreateToDoGroup;
using Zeta.BelajarBarengBSI.Shared.ToDoGroups.Queries.GetToDoGroup;
using Zeta.BelajarBarengBSI.Shared.ToDoGroups.Queries.GetToDoGroups;

namespace Zeta.BelajarBarengBSI.WebApi.Areas.V1.Controllers;

public class ToDoGroupsController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateToDoGroupResponse>> CreateToDoGroup([FromForm] CreateToDoGroupCommand command)
    {
        return CreatedAtAction(nameof(CreateToDoGroup), await Mediator.Send(command));
    }

    [HttpPut("{toDoGroupId:guid}")]
    public async Task<ActionResult> UpdateToDoGroup([FromRoute] Guid toDoGroupId, [FromForm] UpdateToDoGroupCommand command)
    {
        if (toDoGroupId != command.ToDoGroupId)
        {
            throw new MismatchException(nameof(UpdateToDoGroupCommand.ToDoGroupId), toDoGroupId, command.ToDoGroupId);
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{toDoGroupId:guid}")]
    public async Task<ActionResult> DeleteToDoGroup([FromRoute] Guid toDoGroupId)
    {
        await Mediator.Send(new DeleteToDoGroupCommand { ToDoGroupId = toDoGroupId });

        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedListResponse<GetToDoGroupsToDoGroup>>> GetToDoGroups([FromQuery] GetToDoGroupsQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{toDoGroupId:guid}")]
    public async Task<ActionResult<GetToDoGroupResponse>> GetToDoGroup([FromRoute] Guid toDoGroupId)
    {
        return await Mediator.Send(new GetToDoGroupQuery { ToDoGroupId = toDoGroupId });
    }
}
