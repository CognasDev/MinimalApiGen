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
		QuickStartApi.V1.SampleModelQueryRouteEndpointsMapper mapperV1 = new();
		QuickStartApi.V2.SampleModelQueryRouteEndpointsMapper mapperV2 = new();
		QuickStartApi.V3.SampleModelQueryRouteEndpointsMapper mapperV3 = new();

		RouteGroupBuilder apiVersionRouteV1 = webApplication.GetApiVersionRoute(1);
		RouteGroupBuilder apiVersionRouteV2 = webApplication.GetApiVersionRoute(2);
		RouteGroupBuilder apiVersionRouteV3 = webApplication.GetApiVersionRoute(3);

		mapperV1.MapGetV1(apiVersionRouteV1);
		mapperV2.MapGetV2(apiVersionRouteV2);
		mapperV2.MapGetByIdV2(apiVersionRouteV2);
		mapperV3.MapGetV3(apiVersionRouteV3);
		mapperV3.MapGetByIdV3(apiVersionRouteV3);

    }
}