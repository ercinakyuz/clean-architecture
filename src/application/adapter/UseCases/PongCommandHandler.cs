using Clean.Api.Client.Abstractions;
using Clean.Application.Port.Commands;
using Clean.Domain.Port.Model.Aggregate;
using Clean.Domain.Port.Model.Aggregate.Builder;
using Clean.Domain.Port.Model.Aggregate.OfWork;
using Company.Framework.Core.Exception;
using MediatR;
using MongoDB.Driver;
using ApplicationException = Company.Framework.Application.Exception.ApplicationException;

namespace Clean.Application.Adapter.UseCases;

public class PongCommandHandler : IRequestHandler<PongCommand>
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

    public async Task Handle(PongCommand command, CancellationToken cancellationToken)
    {
        var action = (await _actionBuilder.BuildAsync(command.Id, cancellationToken))
            .ThrowOnFail(error => new ApplicationException(ExceptionState.UnProcessable, error))
            .Pong(new PongActionDto(command.Modified));
        await _actionOfWork.UpdateAsync(action, cancellationToken);
    }
}