using Clean.Domain.Port.Model.Aggregate.Converter;
using Clean.Output.Port.Data.Entities;
using Action = Clean.Domain.Port.Model.Aggregate.Action;

namespace Clean.Domain.Adapter.Model.Aggregate.Converter;

public class ActionConverter : IActionConverter
{
    public ActionEntity Convert(Action aggregate)
    {
        return new ActionEntity(aggregate.Id.Value, aggregate.State?.Value, aggregate.Created, aggregate.Modified);
    }
}