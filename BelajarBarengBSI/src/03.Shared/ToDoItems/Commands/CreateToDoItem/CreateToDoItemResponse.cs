using Zeta.BelajarBarengBSI.Shared.Common.Responses;

namespace Zeta.BelajarBarengBSI.Shared.ToDoItems.Commands.CreateToDoItem;

public class CreateToDoItemResponse : Response
{
    public Guid ToDoItemId { get; set; }
}
