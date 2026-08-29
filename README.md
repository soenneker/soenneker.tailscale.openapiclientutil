[![](https://img.shields.io/nuget/v/soenneker.tailscale.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.tailscale.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.tailscale.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.tailscale.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.tailscale.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.tailscale.openapiclientutil/)

# Soenneker.Tailscale.OpenApiClientUtil

Exposes a cached OpenAPI client instance.

## Install

```bash
dotnet add package Soenneker.Tailscale.OpenApiClientUtil
```

## Quick start

```csharp
using Soenneker.Tailscale.OpenApiClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddTailscaleOpenApiClientUtilAsSingleton();
```

Adds `TailscaleOpenApiClientUtil` as a singleton service.

## What you get

- `ITailscaleOpenApiClientUtil` — Exposes a cached OpenAPI client instance.
- `TailscaleOpenApiClientUtilRegistrar` — Registers the OpenAPI client utility for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `TailscaleOpenApiClientUtilRegistrar.AddTailscaleOpenApiClientUtilAsSingleton(services)` | Adds `TailscaleOpenApiClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `TailscaleOpenApiClientUtilRegistrar.AddTailscaleOpenApiClientUtilAsScoped(services)` | Adds `TailscaleOpenApiClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Dispose instances you own when their scope ends so held resources can be released.
