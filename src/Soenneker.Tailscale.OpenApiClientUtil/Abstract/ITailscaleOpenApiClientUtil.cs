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
    ValueTask<TailscaleOpenApiClient> Get(CancellationToken cancellationToken = default);
}
