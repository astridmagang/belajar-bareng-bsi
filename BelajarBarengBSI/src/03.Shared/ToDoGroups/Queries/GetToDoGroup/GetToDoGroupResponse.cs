using Zeta.BelajarBarengBSI.Shared.Common.Responses;

namespace Zeta.BelajarBarengBSI.Shared.ToDoGroups.Queries.GetToDoGroup;

public class GetToDoGroupResponse : Response
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;

    public DateTimeOffset Created { get; set; }
    public DateTimeOffset? Modified { get; set; }

    public IList<GetToDoGroupToDoItem> ToDoItems { get; set; } = new List<GetToDoGroupToDoItem>();
}
