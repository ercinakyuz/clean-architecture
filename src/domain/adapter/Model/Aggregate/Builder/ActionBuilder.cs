using Clean.Domain.Port.Model.Aggregate;
using Clean.Domain.Port.Model.Aggregate.Builder;
using Clean.Domain.Port.Model.Aggregate.Value;
using Clean.Output.Port.Data.Entities;
using Clean.Output.Port.Data.Repositories;
using Company.Framework.Core.Monad;
using Company.Framework.Core.Monad.Extensions;
using static Clean.Domain.Adapter.Model.Aggregate.Builder.Error.ActionBuilderErrors;
using Action = Clean.Domain.Port.Model.Aggregate.Action;

namespace Clean.Domain.Adapter.Model.Aggregate.Builder
{
    public class ActionBuilder : IActionBuilder
    {
        private readonly IActionRepository _actionRepository;

        public ActionBuilder(IActionRepository actionRepository)
        {
            _actionRepository = actionRepository;
        }

        public async Task<Result<Action>> BuildAsync(ActionId id, CancellationToken cancellationToken)
        {
            return (await _actionRepository.FindAsync(id.Value))
                .Map(FromEntity)
                .ToResult(() => ActionNotFound);
        }

        private static Action FromEntity(ActionEntity entity)
        {
            return Action.Load(new LoadActionDto(ActionId.From(entity.Id), entity.Created, entity.Modified));
        }
    }
}
