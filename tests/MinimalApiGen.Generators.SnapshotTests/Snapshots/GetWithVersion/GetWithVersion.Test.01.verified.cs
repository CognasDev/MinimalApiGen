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
		MinimalApiGen.Generators.SnapshotTests.Fixtures.SampleModelQueryRouteEndpointsMapper mapperV2 = new();
		RouteGroupBuilder apiVersionRouteV2 = webApplication.GetApiVersionRoute(2);
		mapperV2.MapGetV2(apiVersionRouteV2);

    }
}
