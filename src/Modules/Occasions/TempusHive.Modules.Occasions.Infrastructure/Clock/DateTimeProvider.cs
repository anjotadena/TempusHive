using TempusHive.Common.Application.Clock;

namespace TempusHive.Modules.Occasions.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
