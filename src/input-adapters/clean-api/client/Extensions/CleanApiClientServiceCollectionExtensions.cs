using Clean.Api.Client.Abstractions;
using Clean.Api.Client.Implementations;
using Company.Framework.Http.Client.Extensions;
using Company.Framework.Http.Message.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Api.Client.Extensions
{
    public static class CleanApiClientServiceCollectionExtensions
    {
        public static IServiceCollection AddCleanApiClients(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddActionHttpClient();
        }

        public static IServiceCollection AddActionHttpClient(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<HttpRequestMessageBuilder>()
                .AddCoreHttpClient<IActionHttpClient, ActionHttpClient>("Action")
                .Services;
        }
    }
}
