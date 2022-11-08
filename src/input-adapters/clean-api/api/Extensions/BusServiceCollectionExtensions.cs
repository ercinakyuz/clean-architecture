using Clean.Output.Adapter.Bus.Extensions;
using Company.Framework.Messaging.Bus.Extensions;

namespace Clean.Api.Extensions
{
    public static class BusServiceCollectionExtensions
    {
        public static IServiceCollection AddBusComponents(this IServiceCollection serviceCollection)
        {
            return serviceCollection.BusServiceBuilder()
                .BuildTaskRabbit()
                .BuildTaskKafka()
                .BuildBusServices();
        }
    }
}
