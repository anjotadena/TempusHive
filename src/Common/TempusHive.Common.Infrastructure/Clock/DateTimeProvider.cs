using TempusHive.Common.Application.Clock;

namespace TempusHive.Common.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
