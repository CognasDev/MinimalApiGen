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
    public static void UseQueryRouteMaps(this WebApplication webApplication)
    {
		QuickStartApi.V1.Query.SampleModelQueryRouteEndpointsMapper mapperV1 = new();
		QuickStartApi.V1.Query.SampleModelQueryRouteEndpointsMapper mapperV2 = new();

		RouteGroupBuilder apiVersionRouteV1 = webApplication.GetApiVersionRoute(1);
		RouteGroupBuilder apiVersionRouteV2 = webApplication.GetApiVersionRoute(2);

		mapperV1.MapGetV1(apiVersionRouteV1);
		mapperV2.MapGetByIdV2(apiVersionRouteV2);

    }
}