using Company.Framework.Core.Id.Implementations;

namespace Clean.Domain.Port.Model.Aggregate.Value
{
    public record ActionId(Guid Value) : IdOfGuid<ActionId>(Value);

}
