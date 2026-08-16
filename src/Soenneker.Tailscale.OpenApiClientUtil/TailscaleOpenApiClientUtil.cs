using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Tailscale.HttpClients.Abstract;
using Soenneker.Tailscale.OpenApiClientUtil.Abstract;
using Soenneker.Tailscale.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Tailscale.OpenApiClientUtil;

///<inheritdoc cref="ITailscaleOpenApiClientUtil"/>
public sealed class TailscaleOpenApiClientUtil : ITailscaleOpenApiClientUtil
{
    private readonly AsyncSingleton<TailscaleOpenApiClient> _client;

    public TailscaleOpenApiClientUtil(ITailscaleOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<TailscaleOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Tailscale:ApiKey");
            string authHeaderName = configuration["Tailscale:AuthHeaderName"] ?? "Authorization";
            string authHeaderValueTemplate = configuration["Tailscale:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerName: authHeaderName, headerValue: authHeaderValue),
                httpClient: httpClient);

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
