using Clean.Domain.Port.Model.Aggregate.Value;
using MediatR;

namespace Clean.Application.Port.Commands;

public record PongCommand(ActionId Id) : IRequest;