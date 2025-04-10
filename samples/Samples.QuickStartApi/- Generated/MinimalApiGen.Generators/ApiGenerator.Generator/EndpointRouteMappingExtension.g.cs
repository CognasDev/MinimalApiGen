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
		RouteGroupBuilder apiVersionRouteV1 = webApplication.GetApiVersionRoute(1);
		RouteGroupBuilder apiVersionRouteV2 = webApplication.GetApiVersionRoute(2);

		Samples.QuickStartApi.V1.Command.SampleModelCommandRouteEndpointsMapper sampleModelCommandRouteEndpointsMapperV1 = new();
		Samples.QuickStartApi.V1.Command.SampleModelCommandRouteEndpointsMapper sampleModelCommandRouteEndpointsMapperV2 = new();
		Samples.QuickStartApi.V1.Query.SampleModelQueryRouteEndpointsMapper sampleModelQueryRouteEndpointsMapperV1 = new();

		sampleModelCommandRouteEndpointsMapperV1.MapPostV1(apiVersionRouteV1);
		sampleModelCommandRouteEndpointsMapperV1.MapPutV1(apiVersionRouteV1);
		sampleModelCommandRouteEndpointsMapperV2.MapDeleteV2(apiVersionRouteV2);
		sampleModelQueryRouteEndpointsMapperV1.MapGetV1(apiVersionRouteV1);
		sampleModelQueryRouteEndpointsMapperV1.MapGetByIdV1(apiVersionRouteV1);

    }
}