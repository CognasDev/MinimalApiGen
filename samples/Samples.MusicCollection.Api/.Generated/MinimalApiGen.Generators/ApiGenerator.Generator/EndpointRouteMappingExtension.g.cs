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

		Samples.MusicCollection.Api.Albums.AlbumQueryRouteEndpointsMapper albumQueryRouteEndpointsMapper = new();

		albumQueryRouteEndpointsMapper.MapGetV1(apiVersionRouteV1);
		albumQueryRouteEndpointsMapper.MapGetByIdV1(apiVersionRouteV1);

    }
}