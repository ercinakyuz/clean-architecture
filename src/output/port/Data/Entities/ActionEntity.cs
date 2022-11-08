using Company.Framework.Core.Logging;
using Company.Framework.Data.Entity;

namespace Clean.Output.Port.Data.Entities
{
    public record ActionEntity(Guid Id, string? State, Log Created, Log? Modified = default)
        : CoreEntity<Guid>(Id, State, Created, Modified);
}
