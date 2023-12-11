using Zeta.BelajarBarengBSI.Application.Services.DateAndTime;

namespace Zeta.BelajarBarengBSI.Infrastructure.DateAndTime;

public class DateAndTimeService : IDateAndTimeService
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}
