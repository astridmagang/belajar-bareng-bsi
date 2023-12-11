using Zeta.BelajarBarengBSI.Base.TodoItems.Enums;

namespace Zeta.BelajarBarengBSI.Shared.ToDoItems.Queries.GetToDoItemsByToDoGroupId;

public class GetToDoItemsByToDoGroupIdToDoItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public PriorityLevel PriorityLevel { get; set; }
    public bool IsDone { get; set; }

    public DateTimeOffset Created { get; set; }
    public DateTimeOffset? Modified { get; set; }
}
