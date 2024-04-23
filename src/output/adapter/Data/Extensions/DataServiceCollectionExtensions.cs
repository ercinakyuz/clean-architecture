using Clean.Output.Adapter.Data.Repositories;
using Clean.Output.Port.Data.Repositories;
using Company.Framework.Data.Db.Provider.Extensions;
using Company.Framework.Data.Mongo.Extensions;
using Company.Framework.Data.Repository.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Output.Adapter.Data.Extensions
{
    public static class DataServiceCollectionExtensions
    {
        public static IServiceCollection AddDataComponents(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return serviceCollection
                .AddDbProvider(configuration)
                .AddRepositories();
        }

        private static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddMongoDb()
                .AddMongoRepository<IActionRepository, ActionRepository>(new RepositorySettings("task-mongo", "task-mongo-context", "actions"));
        }
    }
}
