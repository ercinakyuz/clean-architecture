using Clean.Domain.Port.Model.Aggregate.Converter;
using Clean.Domain.Port.Model.Aggregate.OfWork;
using Clean.Output.Port.Data.Repositories;
using Action = Clean.Domain.Port.Model.Aggregate.Action;

namespace Clean.Domain.Adapter.Model.Aggregate.OfWork;

public class ActionOfWork : IActionOfWork
{
    private readonly IActionRepository _actionRepository;

    private readonly IActionConverter _actionConverter;

    public ActionOfWork(IActionRepository actionRepository, IActionConverter actionConverter)
    {
        _actionRepository = actionRepository;
        _actionConverter = actionConverter;
    }

    public async Task InsertAsync(Action aggregate, CancellationToken cancellationToken)
    {
        await _actionRepository.InsertAsync(_actionConverter.Convert(aggregate));
    }

    public async Task UpdateAsync(Action aggregate, CancellationToken cancellationToken)
    {
        if (aggregate.HasAnyChanges())
            await _actionRepository.UpdateAsync(_actionConverter.Convert(aggregate));
    }

    public async Task DeleteAsync(Action aggregate, CancellationToken cancellationToken)
    {
        await _actionRepository.DeleteAsync(aggregate.Id.Value);
    }
}