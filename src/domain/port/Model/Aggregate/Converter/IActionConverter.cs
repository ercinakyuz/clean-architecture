using Clean.Output.Port.Data.Entities;
using Company.Framework.Domain.Model.Aggregate.Converter;

namespace Clean.Domain.Port.Model.Aggregate.Converter;

public interface IActionConverter : IAggregateConverter<Action, ActionEntity>
{
}