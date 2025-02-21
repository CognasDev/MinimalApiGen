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

		Samples.QuickStartApi.V1.Command.SampleModelCommandRouteEndpointsMapper sampleModelCommandRouteEndpointsMapper = new();
		Samples.QuickStartApi.V1.Query.SampleModelQueryRouteEndpointsMapper sampleModelQueryRouteEndpointsMapper = new();

		sampleModelCommandRouteEndpointsMapper.MapPostV1(apiVersionRouteV1);
		sampleModelCommandRouteEndpointsMapper.MapPutV1(apiVersionRouteV1);
		sampleModelCommandRouteEndpointsMapper.MapDeleteV1(apiVersionRouteV1);
		sampleModelQueryRouteEndpointsMapper.MapGetV1(apiVersionRouteV1);
		sampleModelQueryRouteEndpointsMapper.MapGetByIdV1(apiVersionRouteV1);

    }
}