using MinimalApiGen.Framework.Mapping;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public static class MappingRegistrations
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void AddMinimalApiFramewokMappingServices(this WebApplicationBuilder builder)
    {
		builder.Services.AddSingleton<IMappingService<Samples.MusicCollection.Api.Albums.Album, Samples.MusicCollection.Api.Albums.AlbumResponse>, Samples.MusicCollection.Api.Albums.PostAlbumToAlbumResponseMappingServiceV1>();
		builder.Services.AddSingleton<IMappingService<Samples.MusicCollection.Api.Albums.AlbumRequest, Samples.MusicCollection.Api.Albums.Album>, Samples.MusicCollection.Api.Albums.PostAlbumRequestToAlbumMappingServiceV1>();
		builder.Services.AddSingleton<IMappingService<Samples.MusicCollection.Api.Artists.Artist, Samples.MusicCollection.Api.Artists.ArtistResponse>, Samples.MusicCollection.Api.Artists.GetArtistToArtistResponseMappingServiceV1>();
		builder.Services.AddSingleton<IMappingService<Samples.MusicCollection.Api.Genres.Genre, Samples.MusicCollection.Api.Genres.GenreResponse>, Samples.MusicCollection.Api.Genres.GetGenreToGenreResponseMappingServiceV1>();
		builder.Services.AddSingleton<IMappingService<Samples.MusicCollection.Api.Keys.Key, Samples.MusicCollection.Api.Keys.KeyResponse>, Samples.MusicCollection.Api.Keys.GetKeyToKeyResponseMappingServiceV1>();
		builder.Services.AddSingleton<IMappingService<Samples.MusicCollection.Api.Labels.Label, Samples.MusicCollection.Api.Labels.LabelResponse>, Samples.MusicCollection.Api.Labels.GetLabelToLabelResponseMappingServiceV1>();
		builder.Services.AddSingleton<IMappingService<Samples.MusicCollection.Api.Tracks.Track, Samples.MusicCollection.Api.Tracks.TrackResponse>, Samples.MusicCollection.Api.Tracks.GetTrackToTrackResponseMappingServiceV1>();

    }
}