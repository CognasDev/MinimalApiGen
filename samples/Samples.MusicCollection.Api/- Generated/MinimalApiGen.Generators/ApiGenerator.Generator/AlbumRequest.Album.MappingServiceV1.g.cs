using MinimalApiGen.Framework.Mapping;
using Album = Samples.MusicCollection.Api.Albums.Album;
using AlbumRequest = Samples.MusicCollection.Api.Albums.AlbumRequest;

namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
public sealed class PostAlbumRequestToAlbumMappingServiceV1 : MappingServiceBase<AlbumRequest, Album>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public override Album Map(AlbumRequest request)
    {
        Album model = new()
        {
			AlbumId = request.AlbumId,
			ArtistId = request.ArtistId,
			GenreId = request.GenreId,
			LabelId = request.LabelId,
			Name = request.Name,
			ReleaseDate = request.ReleaseDate
        };
        return model;
    }

    #endregion
}