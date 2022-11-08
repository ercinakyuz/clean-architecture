using Clean.Application.Port.Commands;
using Clean.Domain.Port.Model.Aggregate.Event;
using Company.Framework.Messaging.Envelope;
using MediatR;

namespace Clean.PingAppliedKafkaConsumer
{
    public class PingAppliedEventHandler : INotificationHandler<Envelope<PingApplied>>
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
            await _sender.Send(new PongCommand(notification.Message.AggregateId), cancellationToken);
            _logger.LogInformation("PingApplied KafkaEvent consumed, {notification}", notification);
        }
    }
}
