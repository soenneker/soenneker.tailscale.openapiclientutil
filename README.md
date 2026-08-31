[![](https://img.shields.io/nuget/v/soenneker.tailscale.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.tailscale.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.tailscale.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.tailscale.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.tailscale.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.tailscale.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.tailscale.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.tailscale.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Tailscale.OpenApiClientUtil

Provides a lazily initialized `TailscaleOpenApiClient` backed by the authenticated, cached Tailscale `HttpClient`.

## Installation

```bash
dotnet add package Soenneker.Tailscale.OpenApiClientUtil
```

## Configuration

```json
{
  "Tailscale": {
    "ApiKey": "tskey-api-..."
  }
}
```

## Usage

```csharp
using Soenneker.Tailscale.OpenApiClient;
using Soenneker.Tailscale.OpenApiClient.Models;
using Soenneker.Tailscale.OpenApiClientUtil.Abstract;
using Soenneker.Tailscale.OpenApiClientUtil.Registrars;

services.AddTailscaleOpenApiClientUtilAsScoped();

TailscaleOpenApiClient client = await tailscaleClientUtil.Get(cancellationToken);
ListTailnetDevices200Response? response = await client.Tailnet["-"].Devices.GetAsync(
    cancellationToken: cancellationToken);
```

The scoped registration uses a singleton HTTP provider. Disposing the scoped utility releases its generated client wrapper without removing the shared authenticated `HttpClient`; the HTTP provider disposes that client at application shutdown.
