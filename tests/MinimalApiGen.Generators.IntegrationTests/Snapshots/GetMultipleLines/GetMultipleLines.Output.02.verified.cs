//HintName: EndpointRouteMappingExtension.Query.g.cs
using Microsoft.AspNetCore.Builder;
using MinimalApiGen.Framework.Versioning;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public static class EndpointRouteMappingExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="webApplication"></param>
    public static void UseMinimalApiGenEndpointRouteMaps(this WebApplication webApplication)
    {
		MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModelQueryRouteEndpointsMapper mapperV1 = new();
		RouteGroupBuilder apiVersionRouteV1 = webApplication.GetApiVersionRoute(1);
		mapperV1.MapGetV1(apiVersionRouteV1);
		MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModelQueryRouteEndpointsMapper mapperV2 = new();
		RouteGroupBuilder apiVersionRouteV2 = webApplication.GetApiVersionRoute(2);
		mapperV2.MapGetV2(apiVersionRouteV2);

    }
}
