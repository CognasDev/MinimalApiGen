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

		Samples.MusicCollection.Api.Albums.AlbumCommandRouteEndpointsMapper albumCommandRouteEndpointsMapperV1 = new();
		Samples.MusicCollection.Api.Albums.AlbumQueryRouteEndpointsMapper albumQueryRouteEndpointsMapperV1 = new();
		Samples.MusicCollection.Api.Artists.ArtistCommandRouteEndpointsMapper artistCommandRouteEndpointsMapperV1 = new();
		Samples.MusicCollection.Api.Artists.ArtistQueryRouteEndpointsMapper artistQueryRouteEndpointsMapperV1 = new();
		Samples.MusicCollection.Api.Genres.GenreCommandRouteEndpointsMapper genreCommandRouteEndpointsMapperV1 = new();
		Samples.MusicCollection.Api.Genres.GenreQueryRouteEndpointsMapper genreQueryRouteEndpointsMapperV1 = new();
		Samples.MusicCollection.Api.Keys.KeyQueryRouteEndpointsMapper keyQueryRouteEndpointsMapperV1 = new();
		Samples.MusicCollection.Api.Labels.LabelCommandRouteEndpointsMapper labelCommandRouteEndpointsMapperV1 = new();
		Samples.MusicCollection.Api.Labels.LabelQueryRouteEndpointsMapper labelQueryRouteEndpointsMapperV1 = new();
		Samples.MusicCollection.Api.Tracks.TrackCommandRouteEndpointsMapper trackCommandRouteEndpointsMapperV1 = new();
		Samples.MusicCollection.Api.Tracks.TrackQueryRouteEndpointsMapper trackQueryRouteEndpointsMapperV1 = new();

		albumCommandRouteEndpointsMapperV1.MapPostV1(apiVersionRouteV1);
		albumCommandRouteEndpointsMapperV1.MapPutV1(apiVersionRouteV1);
		albumCommandRouteEndpointsMapperV1.MapDeleteV1(apiVersionRouteV1);
		albumQueryRouteEndpointsMapperV1.MapGetV1(apiVersionRouteV1);
		albumQueryRouteEndpointsMapperV1.MapGetByIdV1(apiVersionRouteV1);
		artistCommandRouteEndpointsMapperV1.MapPostV1(apiVersionRouteV1);
		artistCommandRouteEndpointsMapperV1.MapPutV1(apiVersionRouteV1);
		artistCommandRouteEndpointsMapperV1.MapDeleteV1(apiVersionRouteV1);
		artistQueryRouteEndpointsMapperV1.MapGetV1(apiVersionRouteV1);
		artistQueryRouteEndpointsMapperV1.MapGetByIdV1(apiVersionRouteV1);
		genreCommandRouteEndpointsMapperV1.MapPostV1(apiVersionRouteV1);
		genreCommandRouteEndpointsMapperV1.MapPutV1(apiVersionRouteV1);
		genreCommandRouteEndpointsMapperV1.MapDeleteV1(apiVersionRouteV1);
		genreQueryRouteEndpointsMapperV1.MapGetV1(apiVersionRouteV1);
		genreQueryRouteEndpointsMapperV1.MapGetByIdV1(apiVersionRouteV1);
		keyQueryRouteEndpointsMapperV1.MapGetV1(apiVersionRouteV1);
		keyQueryRouteEndpointsMapperV1.MapGetByIdV1(apiVersionRouteV1);
		labelCommandRouteEndpointsMapperV1.MapPostV1(apiVersionRouteV1);
		labelCommandRouteEndpointsMapperV1.MapPutV1(apiVersionRouteV1);
		labelCommandRouteEndpointsMapperV1.MapDeleteV1(apiVersionRouteV1);
		labelQueryRouteEndpointsMapperV1.MapGetV1(apiVersionRouteV1);
		labelQueryRouteEndpointsMapperV1.MapGetByIdV1(apiVersionRouteV1);
		trackCommandRouteEndpointsMapperV1.MapPostV1(apiVersionRouteV1);
		trackCommandRouteEndpointsMapperV1.MapPutV1(apiVersionRouteV1);
		trackCommandRouteEndpointsMapperV1.MapDeleteV1(apiVersionRouteV1);
		trackQueryRouteEndpointsMapperV1.MapGetV1(apiVersionRouteV1);
		trackQueryRouteEndpointsMapperV1.MapGetByIdV1(apiVersionRouteV1);

    }
}