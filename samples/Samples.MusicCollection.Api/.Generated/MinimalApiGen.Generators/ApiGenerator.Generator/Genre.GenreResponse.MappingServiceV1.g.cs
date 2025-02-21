using MinimalApiGen.Framework.Mapping;
using Genre = Samples.MusicCollection.Api.Genres.Genre;
using GenreResponse = Samples.MusicCollection.Api.Genres.GenreResponse;

namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
public sealed class GetGenreToGenreResponseMappingServiceV1 : MappingServiceBase<Genre, GenreResponse>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public override GenreResponse Map(Genre model)
    {
        GenreResponse response = new()
        {
			GenreId = model.GenreId,
			Name = model.Name,

        };
        return response;
    }

    #endregion
}