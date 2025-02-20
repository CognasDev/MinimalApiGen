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
		RouteGroupBuilder apiVersionRouteV1 = webApplication.GetApiVersionRoute(1);
		RouteGroupBuilder apiVersionRouteV2 = webApplication.GetApiVersionRoute(2);

		MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModelQueryRouteEndpointsMapper sampleModelQueryRouteEndpointsMapper = new();
		MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModelQueryRouteEndpointsMapper sampleModelQueryRouteEndpointsMapper = new();

		sampleModelQueryRouteEndpointsMapper.MapGetV1(apiVersionRouteV1);
		sampleModelQueryRouteEndpointsMapper.MapGetV2(apiVersionRouteV2);

    }
}