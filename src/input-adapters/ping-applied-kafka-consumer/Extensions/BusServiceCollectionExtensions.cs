using Clean.Domain.Port.Model.Aggregate.Event;
using Clean.Output.Adapter.Bus.Extensions;
using Company.Framework.Messaging.Bus.Extensions;
using Company.Framework.Messaging.Envelope;

namespace Clean.PingAppliedKafkaConsumer.Extensions
{
    public static class BusServiceCollectionExtensions
    {
        public static IServiceCollection AddBusComponents(this IServiceCollection serviceCollection)
        {
            return serviceCollection.BusServiceBuilder()
                .BuildTaskKafkaThatConsume<Envelope<PingApplied>>("PingApplied")
                .BuildTaskRabbit()
                .BuildBusServices();
        }
    }
}
