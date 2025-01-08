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
    public static void UseCommandRouteMaps(this WebApplication webApplication)
    {
		QuickStartApi.V1.Command.SampleModelCommandRouteEndpointsMapper mapperV1 = new();

		RouteGroupBuilder apiVersionRouteV1 = webApplication.GetApiVersionRoute(1);

		mapperV1.MapPostV1(apiVersionRouteV1);

    }
}