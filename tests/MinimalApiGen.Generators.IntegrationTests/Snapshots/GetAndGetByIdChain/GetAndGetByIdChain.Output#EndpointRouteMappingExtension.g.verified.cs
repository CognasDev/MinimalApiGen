//HintName: EndpointRouteMappingExtension.g.cs
using Microsoft.AspNetCore.Builder;
using MinimalApiGen.Framework.Versioning;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public static partial class EndpointRouteMappingExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="webApplication"></param>
    public static void UseRouteMaps(this WebApplication webApplication)
    {
		RouteGroupBuilder apiVersionRouteV3 = webApplication.GetApiVersionRoute(3);

		MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModelQueryRouteEndpointsMapper sampleModelQueryRouteEndpointsMapper = new();

		sampleModelQueryRouteEndpointsMapper.MapGetV3(apiVersionRouteV3);
		sampleModelQueryRouteEndpointsMapper.MapGetByIdV3(apiVersionRouteV3);

    }
}