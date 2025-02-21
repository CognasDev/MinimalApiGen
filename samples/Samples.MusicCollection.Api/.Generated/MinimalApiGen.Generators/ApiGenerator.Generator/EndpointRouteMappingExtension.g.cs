﻿using Microsoft.AspNetCore.Builder;
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
		Samples.MusicCollection.Api.Artists.ArtistQueryRouteEndpointsMapper artistQueryRouteEndpointsMapper = new();
		Samples.MusicCollection.Api.Genres.GenreQueryRouteEndpointsMapper genreQueryRouteEndpointsMapper = new();
		Samples.MusicCollection.Api.Keys.KeyQueryRouteEndpointsMapper keyQueryRouteEndpointsMapper = new();
		Samples.MusicCollection.Api.Labels.LabelQueryRouteEndpointsMapper labelQueryRouteEndpointsMapper = new();
		Samples.MusicCollection.Api.Tracks.TrackQueryRouteEndpointsMapper trackQueryRouteEndpointsMapper = new();

		albumQueryRouteEndpointsMapper.MapGetV1(apiVersionRouteV1);
		albumQueryRouteEndpointsMapper.MapGetByIdV1(apiVersionRouteV1);
		artistQueryRouteEndpointsMapper.MapGetV1(apiVersionRouteV1);
		artistQueryRouteEndpointsMapper.MapGetByIdV1(apiVersionRouteV1);
		genreQueryRouteEndpointsMapper.MapGetV1(apiVersionRouteV1);
		genreQueryRouteEndpointsMapper.MapGetByIdV1(apiVersionRouteV1);
		keyQueryRouteEndpointsMapper.MapGetV1(apiVersionRouteV1);
		keyQueryRouteEndpointsMapper.MapGetByIdV1(apiVersionRouteV1);
		labelQueryRouteEndpointsMapper.MapGetV1(apiVersionRouteV1);
		labelQueryRouteEndpointsMapper.MapGetByIdV1(apiVersionRouteV1);
		trackQueryRouteEndpointsMapper.MapGetV1(apiVersionRouteV1);
		trackQueryRouteEndpointsMapper.MapGetByIdV1(apiVersionRouteV1);

    }
}