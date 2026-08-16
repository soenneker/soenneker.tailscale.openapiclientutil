using Soenneker.Tailscale.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Tailscale.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class TailscaleOpenApiClientUtilTests : HostedUnitTest
{
    private readonly ITailscaleOpenApiClientUtil _openapiclientutil;

    public TailscaleOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<ITailscaleOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
