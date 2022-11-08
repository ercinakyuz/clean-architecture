using Clean.Api.Client.Abstractions;
using Company.Framework.Http.Client;
using Company.Framework.Http.Message.Builder;

namespace Clean.Api.Client.Implementations
{
    public class ActionHttpClient : CoreHttpClient, IActionHttpClient
    {
        public ActionHttpClient(HttpClient httpClient, HttpRequestMessageBuilder httpRequestMessageBuilder) : base(httpClient, httpRequestMessageBuilder)
        {
        }

        public async Task PingAsync(CancellationToken cancellationToken)
        {
            await PostAsync("ping", new object(), cancellationToken);
        }
        public async Task PongAsync(CancellationToken cancellationToken)
        {
            await PatchAsync("pong", new object(), cancellationToken);
        }
    }
}
