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

		TestNamespace.SampleModelCommandRouteEndpointsMapper sampleModelCommandRouteEndpointsMapper = new();

		sampleModelCommandRouteEndpointsMapper.MapPutV1(apiVersionRouteV1);

    }
}