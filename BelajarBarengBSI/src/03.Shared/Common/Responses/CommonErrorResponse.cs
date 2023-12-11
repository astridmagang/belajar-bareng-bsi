namespace Zeta.BelajarBarengBSI.Shared.Common.Responses;

public class CommonErrorResponse : ErrorResponse
{
    public override IList<string> Details => new List<string> { Detail };
}
