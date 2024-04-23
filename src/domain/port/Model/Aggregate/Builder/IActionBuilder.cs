using Clean.Domain.Port.Model.Aggregate.Value;
using Company.Framework.Core.Monad;

namespace Clean.Domain.Port.Model.Aggregate.Builder;

public interface IActionBuilder
{
    Task<Result<Action>> BuildAsync(ActionId id, CancellationToken cancellationToken);
}