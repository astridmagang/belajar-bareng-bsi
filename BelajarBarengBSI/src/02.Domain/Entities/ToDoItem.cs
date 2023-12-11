using Zeta.BelajarBarengBSI.Base.TodoItems.Enums;
using Zeta.BelajarBarengBSI.Domain.Abstracts;

namespace Zeta.BelajarBarengBSI.Domain.Entities;

public class ToDoItem : ModifiableEntity
{
    public Guid ToDoGroupId { get; set; }
    public ToDoGroup ToDoGroup { get; set; } = default!;

    public string Title { get; set; } = default!;
    public string? Description { get; set; } = default!;
    public PriorityLevel PriorityLevel { get; set; }
    public bool IsDone { get; set; }
}
