using MinimalApiGen.Framework.Mapping;
using Album = Samples.MusicCollection.Api.Albums.Album;
using AlbumResponse = Samples.MusicCollection.Api.Albums.AlbumResponse;

namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
public sealed class PostAlbumToAlbumResponseMappingServiceV1 : MappingServiceBase<Album, AlbumResponse>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public override AlbumResponse Map(Album model)
    {
        AlbumResponse response = new()
        {
			AlbumId = model.AlbumId,
			ArtistId = model.ArtistId,
			GenreId = model.GenreId,
			LabelId = model.LabelId,
			Name = model.Name,
			ReleaseDate = model.ReleaseDate,

        };
        return response;
    }

    #endregion
}