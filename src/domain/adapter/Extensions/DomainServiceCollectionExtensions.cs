using Clean.Domain.Adapter.Model.Aggregate.Builder;
using Clean.Domain.Adapter.Model.Aggregate.Converter;
using Clean.Domain.Adapter.Model.Aggregate.OfWork;
using Clean.Domain.Port.Model.Aggregate.Builder;
using Clean.Domain.Port.Model.Aggregate.Converter;
using Clean.Domain.Port.Model.Aggregate.OfWork;
using Company.Framework.Domain.Model.Aggregate.OfWork.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Domain.Adapter.Extensions
{
    public static class DomainServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainComponents(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddActionAggregation();
        }

        private static IServiceCollection AddActionAggregation(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IActionBuilder, ActionBuilder>()
                .AddAggregateOfWork<IActionOfWork, ActionOfWork>()
                .AddSingleton<IActionConverter, ActionConverter>();
        }
    }
}
