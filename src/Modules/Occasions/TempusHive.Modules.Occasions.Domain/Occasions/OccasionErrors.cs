

using TempusHive.Common.Domain;

namespace TempusHive.Modules.Occasions.Domain.Occasions;

public static class OccasionErrors
{
    public static Error NotFound(Guid occasionId) =>
        Error.NotFound("Occasions.NotFound", $"The occasion with the identifier {occasionId} was not found");

    public static readonly Error StartDateInPast = Error.Problem(
        "Occasions.StartDateInPast",
        "The Occasion start date is in the past");

    public static readonly Error EndDatePrecedesStartDate = Error.Problem(
        "Occasions.EndDatePrecedesStartDate",
        "The Occasion end date precedes the start date");

    public static readonly Error NoTicketsFound = Error.Problem(
        "Occasions.NoTicketsFound",
        "The Occasion does not have any ticket types defined");

    public static readonly Error NotDraft = Error.Problem("Occasions.NotDraft", "The Occasion is not in draft status");


    public static readonly Error AlreadyCanceled = Error.Problem(
        "Occasions.AlreadyCanceled",
        "The Occasion was already canceled");


    public static readonly Error AlreadyStarted = Error.Problem(
        "Occasions.AlreadyStarted",
        "The Occasion has already started");
}
