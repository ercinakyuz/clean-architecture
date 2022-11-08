using Clean.Api.Client.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Output.Adapter.Http.Extensions
{
    public static class HttpClientsServiceCollectionExtensions
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddCleanApiClients();
        }
    }
}
