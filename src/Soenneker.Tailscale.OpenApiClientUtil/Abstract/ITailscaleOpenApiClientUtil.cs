using Soenneker.Tailscale.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Tailscale.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface ITailscaleOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured tailscale OpenAPI Client used by the Tailscale OpenAPI Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested tailscale OpenAPI Client.</returns>
    ValueTask<TailscaleOpenApiClient> Get(CancellationToken cancellationToken = default);
}
