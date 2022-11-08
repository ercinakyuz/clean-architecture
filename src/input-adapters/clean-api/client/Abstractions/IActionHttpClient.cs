using Company.Framework.Http.Client;

namespace Clean.Api.Client.Abstractions;

public interface IActionHttpClient : IHttpClient
{
    Task PingAsync(CancellationToken cancellationToken);
    Task PongAsync(CancellationToken cancellationToken);
}
