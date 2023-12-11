using Zeta.BelajarBarengBSI.Domain.Abstracts;

namespace Zeta.BelajarBarengBSI.Domain.Entities;

public class ToDoGroup : ModifiableEntity
{
    public string Name { get; set; } = default!;

    public IList<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
}
