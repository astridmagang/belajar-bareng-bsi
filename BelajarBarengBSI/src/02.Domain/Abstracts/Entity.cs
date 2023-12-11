using Zeta.BelajarBarengBSI.Domain.Interfaces;

namespace Zeta.BelajarBarengBSI.Domain.Abstracts;

public abstract class Entity : ICreatable
{
    public Guid Id { get; set; }
    public DateTimeOffset Created { get; set; }
}
