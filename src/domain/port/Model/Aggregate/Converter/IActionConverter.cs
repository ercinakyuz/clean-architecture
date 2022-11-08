using Clean.Output.Port.Data.Entities;

namespace Clean.Domain.Port.Model.Aggregate.Converter;

public interface IActionConverter
{
    ActionEntity Convert(Action aggregate);
}