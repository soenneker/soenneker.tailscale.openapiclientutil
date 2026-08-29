using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Tailscale.HttpClients.Registrars;
using Soenneker.Tailscale.OpenApiClientUtil.Abstract;

namespace Soenneker.Tailscale.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class TailscaleOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="TailscaleOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddTailscaleOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddTailscaleOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ITailscaleOpenApiClientUtil, TailscaleOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="TailscaleOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddTailscaleOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddTailscaleOpenApiHttpClientAsSingleton()
                .TryAddScoped<ITailscaleOpenApiClientUtil, TailscaleOpenApiClientUtil>();

        return services;
    }
}
