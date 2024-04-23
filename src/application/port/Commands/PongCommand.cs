using Clean.Domain.Port.Model.Aggregate.Value;
using Company.Framework.Core.Logging;
using MediatR;

namespace Clean.Application.Port.Commands;

public record PongCommand(ActionId Id, Log Modified) : IRequest;