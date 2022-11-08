using Clean.Domain.Port.Model.Aggregate.Event;
using Clean.Domain.Port.Model.Aggregate.Value;
using Company.Framework.Domain.Model.Aggregate.Event.Dispatcher;
using Company.Framework.Messaging.Bus.Provider;
using Company.Framework.Messaging.Envelope;
using Company.Framework.Messaging.Kafka.Bus;
using Company.Framework.Messaging.Kafka.Producer;
using Company.Framework.Messaging.Kafka.Producer.Args;
using Company.Framework.Messaging.RabbitMq.Bus;
using Company.Framework.Messaging.RabbitMq.Consumer.Settings;
using Company.Framework.Messaging.RabbitMq.Producer;
using Company.Framework.Messaging.RabbitMq.Producer.Args;
using CorrelationId.Abstractions;
using Microsoft.Extensions.Logging;

namespace Clean.Domain.Adapter.Model.Aggregate.Event.Dispatcher;

public class PingAppliedDispatcher : CoreEventDispatcher<PingApplied>
{
    private readonly IKafkaProducer _actionKafkaProducer;

    private readonly IRabbitProducer _actionRabbitProducer;

    public PingAppliedDispatcher(IBusProvider busProvider,
        ICorrelationContextAccessor correlationContextAccessor,
        ILogger<PingAppliedDispatcher> logger)
        : base(correlationContextAccessor, logger)
    {
        var taskKafkaBus = busProvider.Resolve<IKafkaBus>("TaskKafka");
        var taskRabbitBus = busProvider.Resolve<IRabbitBus>("TaskRabbit");

        _actionKafkaProducer = taskKafkaBus.ProducerContext.Default();
        _actionRabbitProducer = taskRabbitBus.ProducerContext.Default();
    }

    public override async Task DispatchAsync(Envelope<PingApplied> envelope, CancellationToken cancellationToken)
    {
        var kafkaProducerArgs = new KafkaProduceArgs("ping-applied", envelope);
        var rabbitProducerArgs = new RabbitProduceArgs(new RabbitExchangeArgs{Name ="action", Type = "topic"}, "ping-applied", envelope);
        await Task.WhenAll(
            _actionKafkaProducer.ProduceAsync(kafkaProducerArgs, cancellationToken),
            _actionRabbitProducer.ProduceAsync(rabbitProducerArgs, cancellationToken)
        );
    }
}