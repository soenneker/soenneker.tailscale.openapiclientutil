using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Tailscale.HttpClients.Abstract;
using Soenneker.Tailscale.OpenApiClientUtil.Abstract;
using Soenneker.Tailscale.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Tailscale.OpenApiClientUtil;

public sealed class TailscaleOpenApiClientUtil : ITailscaleOpenApiClientUtil
{
    private readonly AsyncSingleton<TailscaleOpenApiClient> _client;

    public TailscaleOpenApiClientUtil(ITailscaleOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<TailscaleOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new TailscaleOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<TailscaleOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
