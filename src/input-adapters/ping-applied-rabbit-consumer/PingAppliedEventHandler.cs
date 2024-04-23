using Clean.Application.Port.Commands;
using Clean.Domain.Port.Model.Aggregate.Event;
using Company.Framework.Messaging.Envelope;
using MediatR;

namespace Clean.PingAppliedRabbitConsumer
{
    public class PingAppliedEventHandler: INotificationHandler<Envelope<PingApplied>>
    {
        private readonly ISender _sender;
        private readonly ILogger _logger;

        public PingAppliedEventHandler(ISender sender, ILogger<PingAppliedEventHandler> logger)
        {
            _sender = sender;
            _logger = logger;
        }
        public async Task Handle(Envelope<PingApplied> notification, CancellationToken cancellationToken)
        {
            await _sender.Send(new PongCommand(notification.Message.AggregateId, notification.Created), cancellationToken);
            _logger.LogInformation("PingApplied RabbitEvent consumed, {notification}", notification);
        }
    }
}
