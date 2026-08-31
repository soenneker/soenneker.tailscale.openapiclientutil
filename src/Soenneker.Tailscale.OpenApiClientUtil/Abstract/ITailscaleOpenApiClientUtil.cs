using Soenneker.Tailscale.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Tailscale.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a lazily initialized Tailscale OpenAPI client backed by the shared authenticated HTTP client.
/// </summary>
public interface ITailscaleOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Releases the generated client wrapper owned by this utility without disposing the shared HTTP provider.
    /// </summary>
    new void Dispose();

    /// <summary>
    /// Asynchronously releases the generated client wrapper owned by this utility without disposing the shared HTTP provider.
    /// </summary>
    new ValueTask DisposeAsync();

    /// <summary>
    /// Returns the configured tailscale OpenAPI Client used by the Tailscale OpenAPI Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested tailscale OpenAPI Client.</returns>
    ValueTask<TailscaleOpenApiClient> Get(CancellationToken cancellationToken = default);
}
