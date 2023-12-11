using Microsoft.EntityFrameworkCore;
using Zeta.BelajarBarengBSI.Domain.Entities;

namespace Zeta.BelajarBarengBSI.Application.Services.Persistence;

public interface IApplicationDbContext
{
    DbSet<ToDoGroup> ToDoGroups { get; }
    DbSet<ToDoItem> ToDoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
