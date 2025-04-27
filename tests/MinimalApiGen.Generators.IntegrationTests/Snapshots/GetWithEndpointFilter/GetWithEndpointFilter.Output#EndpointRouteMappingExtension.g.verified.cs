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
    public static void UseMinimalApiFrameworkRoutes(this WebApplication webApplication)
    {
		RouteGroupBuilder apiVersionRouteV2 = webApplication.GetApiVersionRoute(2);

		MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModelQueryRouteEndpointsMapper sampleModelQueryRouteEndpointsMapperV2 = new();

		sampleModelQueryRouteEndpointsMapperV2.MapGetV2(apiVersionRouteV2);

    }
}