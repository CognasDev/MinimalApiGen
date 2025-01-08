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
		MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModelQueryRouteEndpointsMapper mapperV3 = new();

		RouteGroupBuilder apiVersionRouteV3 = webApplication.GetApiVersionRoute(3);

		mapperV3.MapGetV3(apiVersionRouteV3);
		mapperV3.MapGetByIdV3(apiVersionRouteV3);

    }
}