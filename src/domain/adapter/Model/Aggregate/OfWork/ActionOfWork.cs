using Clean.Domain.Port.Model.Aggregate.Converter;
using Clean.Domain.Port.Model.Aggregate.OfWork;
using Clean.Domain.Port.Model.Aggregate.State;
using Clean.Domain.Port.Model.Aggregate.Value;
using Clean.Output.Port.Data.Entities;
using Clean.Output.Port.Data.Repositories;
using Company.Framework.Domain.Model.Aggregate.OfWork;
using Action = Clean.Domain.Port.Model.Aggregate.Action;

namespace Clean.Domain.Adapter.Model.Aggregate.OfWork;

public class ActionOfWork : AggregateOfWork<IActionRepository, IActionConverter, Action, ActionId, ActionState, ActionEntity, Guid>, IActionOfWork
{
    public ActionOfWork(IActionRepository repository, IActionConverter converter) : base(repository, converter)
    {
    }
}