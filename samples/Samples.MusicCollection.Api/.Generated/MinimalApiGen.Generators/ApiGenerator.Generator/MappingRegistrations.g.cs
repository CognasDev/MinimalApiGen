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
    public static void AddMappingServices(this WebApplicationBuilder builder)
    {
		builder.Services.AddSingleton<IMappingService<Samples.MusicCollection.Api.Albums.Album, Samples.MusicCollection.Api.Albums.AlbumResponse>, Samples.MusicCollection.Api.Albums.GetAlbumToAlbumResponseMappingServiceV1>();

    }
}