using MediatR;
using Microsoft.EntityFrameworkCore;
using Zeta.BelajarBarengBSI.Application.Common.Exceptions;
using Zeta.BelajarBarengBSI.Application.Services.Persistence;
using Zeta.BelajarBarengBSI.Shared.ToDoGroups.Constants;

namespace Zeta.BelajarBarengBSI.Application.ToDoGroups.Commands.DeleteToDoGroup;

public class DeleteToDoGroupCommand : IRequest
{
    public Guid ToDoGroupId { get; set; }
}

public class DeleteToDoGroupCommandHandler : IRequestHandler<DeleteToDoGroupCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteToDoGroupCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteToDoGroupCommand request, CancellationToken cancellationToken)
    {
        var toDoGroup = await _context.ToDoGroups
            .Where(x => x.Id == request.ToDoGroupId)
            .Include(a => a.ToDoItems)
            .SingleOrDefaultAsync(cancellationToken);

        if (toDoGroup is null)
        {
            throw new NotFoundException(DisplayTextFor.ToDoGroup, request.ToDoGroupId);
        }

        _context.ToDoItems.RemoveRange(toDoGroup.ToDoItems);
        _context.ToDoGroups.Remove(toDoGroup);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
