using Clean.Domain.Port.Model.Aggregate.Event;
using Clean.Output.Adapter.Bus.Extensions;
using Company.Framework.Messaging.Bus.Extensions;
using Company.Framework.Messaging.Envelope;

namespace Clean.PingAppliedRabbitConsumer.Extensions
{
    public static class BusServiceCollectionExtensions
    {
        public static IServiceCollection AddBusComponents(this IServiceCollection serviceCollection)
        {
            return serviceCollection.BusServiceBuilder()
                .BuildTaskRabbitThatConsume<Envelope<PingApplied>>("PingApplied")
                .BuildTaskKafka()
                .BuildBusServices();
        }
    }
}
