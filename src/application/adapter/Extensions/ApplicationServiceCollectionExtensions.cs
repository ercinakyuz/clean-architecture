using Clean.Domain.Adapter.Extensions;
using Clean.Output.Adapter.Data.Extensions;
using Clean.Output.Adapter.Http.Extensions;
using Company.Framework.Mediator.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Application.Adapter.Extensions
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationComponents(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return serviceCollection
                .AddMediator()
                .AddDomainComponents()
                .AddDataComponents(configuration)
                .AddHttpClients();
        }
    }
}
