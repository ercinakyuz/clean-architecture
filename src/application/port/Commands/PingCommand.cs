using MediatR;

namespace Clean.Application.Port.Commands;

public record PingCommand : IRequest<Guid>;