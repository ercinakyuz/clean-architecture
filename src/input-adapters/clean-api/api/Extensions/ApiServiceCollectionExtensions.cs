using System.Text.Json.Serialization;
using Company.Framework.Api.Extensions;
using Company.Framework.Api.Localization.Extensions;
using Company.Framework.Correlation.Extensions;

namespace Clean.Api.Extensions
{
    public static class ApiServiceCollectionExtensions
    {
        public static IServiceCollection AddApiComponents(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            return serviceCollection.AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddCorrelation()
            .AddApiExceptionHandler()
            .AddLocalization<CleanApiResources>();
        }
    }
}
