using Clean.Api.Client.Abstractions;
using Clean.Application.Port.Commands;
using Clean.Domain.Port.Model.Aggregate.Builder;
using Clean.Domain.Port.Model.Aggregate.OfWork;
using Company.Framework.Core.Exception;
using Company.Framework.Domain.Model.Exception;
using MediatR;
using ApplicationException = Company.Framework.Application.Exception.ApplicationException;

namespace Clean.Application.Adapter.UseCases;

public class PongCommandHandler : AsyncRequestHandler<PongCommand>
{
    private readonly IActionBuilder _actionBuilder;
    private readonly IActionOfWork _actionOfWork;
    private readonly IActionHttpClient _actionHttpClient;

    public PongCommandHandler(IActionBuilder actionBuilder, IActionOfWork actionOfWork, IActionHttpClient actionHttpClient)
    {
        _actionBuilder = actionBuilder;
        _actionOfWork = actionOfWork;
        _actionHttpClient = actionHttpClient;
    }

    protected override async Task Handle(PongCommand request, CancellationToken cancellationToken)
    {
        var action = (await _actionBuilder.BuildAsync(request.Id, cancellationToken))
            .IfFail(exception => throw new ApplicationException(ExceptionState.UnProcessable, (AggregateBuilderException)exception))
            .Pong();
        await _actionOfWork.UpdateAsync(action, cancellationToken);
        //await _actionHttpClient.PingAsync(cancellationToken);
    }
}