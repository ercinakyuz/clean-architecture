using Clean.Application.Port.Commands;
using Clean.Domain.Port.Model.Aggregate;
using Clean.Domain.Port.Model.Aggregate.OfWork;
using Company.Framework.Core.Logging;
using MediatR;
using Action = Clean.Domain.Port.Model.Aggregate.Action;

namespace Clean.Application.Adapter.UseCases;

public class PingCommandHandler : IRequestHandler<PingCommand, Guid>
{
    private readonly IActionOfWork _actionOfWork;

    public PingCommandHandler(IActionOfWork actionOfWork)
    {
        _actionOfWork = actionOfWork;
    }

    public async Task<Guid> Handle(PingCommand request, CancellationToken cancellationToken)
    {
        var action = Action.Ping(new PingActionDto(Log.Load("Creator")));
        await _actionOfWork.InsertAsync(action, cancellationToken);
        return action.Id.Value;
    }
}