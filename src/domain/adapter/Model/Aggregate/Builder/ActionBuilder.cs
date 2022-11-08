using Clean.Domain.Port.Model.Aggregate;
using Clean.Domain.Port.Model.Aggregate.Builder;
using Clean.Domain.Port.Model.Aggregate.Value;
using Clean.Output.Port.Data.Repositories;
using LanguageExt.Common;
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
            return (await _actionRepository.GetByIdAsync(id.Value)).Match(
                    entity => new Result<Action>(Action.Load(new LoadActionDto(ActionId.From(entity.Id), entity.Created, entity.Modified))),
                    () => new Result<Action>(ActionNotFound)
                );
        }
    }
}
