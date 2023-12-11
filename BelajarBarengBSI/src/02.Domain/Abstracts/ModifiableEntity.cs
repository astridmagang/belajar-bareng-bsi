using Zeta.BelajarBarengBSI.Domain.Interfaces;

namespace Zeta.BelajarBarengBSI.Domain.Abstracts;

public abstract class ModifiableEntity : Entity, IModifiable
{
    public DateTimeOffset? Modified { get; set; }
}
