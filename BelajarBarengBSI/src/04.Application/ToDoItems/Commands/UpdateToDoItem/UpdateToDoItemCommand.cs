﻿using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zeta.BelajarBarengBSI.Application.Common.Exceptions;
using Zeta.BelajarBarengBSI.Application.Services.Persistence;
using Zeta.BelajarBarengBSI.Shared.ToDoItems.Commands.UpdateToDoItem;
using Zeta.BelajarBarengBSI.Shared.ToDoItems.Constants;

namespace Zeta.BelajarBarengBSI.Application.ToDoItems.Commands.UpdateToDoItem;

public class UpdateToDoItemCommand : UpdateToDoItemRequest, IRequest
{
}

public class UpdateToDoItemCommandValidator : AbstractValidator<UpdateToDoItemCommand>
{
    public UpdateToDoItemCommandValidator()
    {
        Include(new UpdateToDoItemRequestValidator());
    }
}

public class UpdateToDoItemCommandHandler : IRequestHandler<UpdateToDoItemCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateToDoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
    {
        var toDoItem = await _context.ToDoItems
            .Where(x => x.Id == request.ToDoItemId)
            .SingleOrDefaultAsync(cancellationToken);

        if (toDoItem is null)
        {
            throw new NotFoundException(DisplayTextFor.ToDoItem, request.ToDoItemId);
        }

        toDoItem.Title = request.Title;
        toDoItem.Description = request.Description;
        toDoItem.PriorityLevel = request.PriorityLevel;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
