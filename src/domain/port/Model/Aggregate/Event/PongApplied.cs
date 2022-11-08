using Clean.Domain.Port.Model.Aggregate.Value;
using Company.Framework.Domain.Model.Aggregate.Event;

namespace Clean.Domain.Port.Model.Aggregate.Event
{
    public record PongApplied(ActionId AggregateId) : CoreEvent<ActionId>(AggregateId);
}
