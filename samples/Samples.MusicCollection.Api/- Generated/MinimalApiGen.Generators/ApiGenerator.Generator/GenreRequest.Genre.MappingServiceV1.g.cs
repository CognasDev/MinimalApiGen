using MinimalApiGen.Framework.Mapping;
using Genre = Samples.MusicCollection.Api.Genres.Genre;
using GenreRequest = Samples.MusicCollection.Api.Genres.GenreRequest;

namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
public sealed class PostGenreRequestToGenreMappingServiceV1 : MappingServiceBase<GenreRequest, Genre>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public override Genre Map(GenreRequest request)
    {
        Genre model = new()
        {
			GenreId = request.GenreId,
			Name = request.Name,

        };
        return model;
    }

    #endregion
}