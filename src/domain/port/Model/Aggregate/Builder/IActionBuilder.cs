using Clean.Domain.Port.Model.Aggregate.Value;
using LanguageExt.Common;

namespace Clean.Domain.Port.Model.Aggregate.Builder;

public interface IActionBuilder
{
    Task<Result<Action>> BuildAsync(ActionId id, CancellationToken cancellationToken);
}