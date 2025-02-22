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

		Samples.MusicCollection.Api.Albums.AlbumCommandRouteEndpointsMapper albumCommandRouteEndpointsMapper = new();
		Samples.MusicCollection.Api.Albums.AlbumQueryRouteEndpointsMapper albumQueryRouteEndpointsMapper = new();
		Samples.MusicCollection.Api.Artists.ArtistCommandRouteEndpointsMapper artistCommandRouteEndpointsMapper = new();
		Samples.MusicCollection.Api.Artists.ArtistQueryRouteEndpointsMapper artistQueryRouteEndpointsMapper = new();
		Samples.MusicCollection.Api.Genres.GenreCommandRouteEndpointsMapper genreCommandRouteEndpointsMapper = new();
		Samples.MusicCollection.Api.Genres.GenreQueryRouteEndpointsMapper genreQueryRouteEndpointsMapper = new();
		Samples.MusicCollection.Api.Keys.KeyQueryRouteEndpointsMapper keyQueryRouteEndpointsMapper = new();
		Samples.MusicCollection.Api.Labels.LabelCommandRouteEndpointsMapper labelCommandRouteEndpointsMapper = new();
		Samples.MusicCollection.Api.Labels.LabelQueryRouteEndpointsMapper labelQueryRouteEndpointsMapper = new();
		Samples.MusicCollection.Api.Tracks.TrackCommandRouteEndpointsMapper trackCommandRouteEndpointsMapper = new();
		Samples.MusicCollection.Api.Tracks.TrackQueryRouteEndpointsMapper trackQueryRouteEndpointsMapper = new();

		albumCommandRouteEndpointsMapper.MapPostV1(apiVersionRouteV1);
		albumCommandRouteEndpointsMapper.MapPutV1(apiVersionRouteV1);
		albumCommandRouteEndpointsMapper.MapDeleteV1(apiVersionRouteV1);
		albumQueryRouteEndpointsMapper.MapGetV1(apiVersionRouteV1);
		albumQueryRouteEndpointsMapper.MapGetByIdV1(apiVersionRouteV1);
		artistCommandRouteEndpointsMapper.MapPostV1(apiVersionRouteV1);
		artistCommandRouteEndpointsMapper.MapPutV1(apiVersionRouteV1);
		artistCommandRouteEndpointsMapper.MapDeleteV1(apiVersionRouteV1);
		artistQueryRouteEndpointsMapper.MapGetV1(apiVersionRouteV1);
		artistQueryRouteEndpointsMapper.MapGetByIdV1(apiVersionRouteV1);
		genreCommandRouteEndpointsMapper.MapPostV1(apiVersionRouteV1);
		genreCommandRouteEndpointsMapper.MapPutV1(apiVersionRouteV1);
		genreCommandRouteEndpointsMapper.MapDeleteV1(apiVersionRouteV1);
		genreQueryRouteEndpointsMapper.MapGetV1(apiVersionRouteV1);
		genreQueryRouteEndpointsMapper.MapGetByIdV1(apiVersionRouteV1);
		keyQueryRouteEndpointsMapper.MapGetV1(apiVersionRouteV1);
		keyQueryRouteEndpointsMapper.MapGetByIdV1(apiVersionRouteV1);
		labelCommandRouteEndpointsMapper.MapPostV1(apiVersionRouteV1);
		labelCommandRouteEndpointsMapper.MapPutV1(apiVersionRouteV1);
		labelCommandRouteEndpointsMapper.MapDeleteV1(apiVersionRouteV1);
		labelQueryRouteEndpointsMapper.MapGetV1(apiVersionRouteV1);
		labelQueryRouteEndpointsMapper.MapGetByIdV1(apiVersionRouteV1);
		trackCommandRouteEndpointsMapper.MapPostV1(apiVersionRouteV1);
		trackCommandRouteEndpointsMapper.MapPutV1(apiVersionRouteV1);
		trackCommandRouteEndpointsMapper.MapDeleteV1(apiVersionRouteV1);
		trackQueryRouteEndpointsMapper.MapGetV1(apiVersionRouteV1);
		trackQueryRouteEndpointsMapper.MapGetByIdV1(apiVersionRouteV1);

    }
}