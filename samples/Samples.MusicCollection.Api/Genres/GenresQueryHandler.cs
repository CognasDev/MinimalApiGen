using MinimalApiGen.Framework.ApiHandlers;
using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="databaseService"></param>
public sealed class GenresQueryHandler(ILogger<GenresQueryHandler> logger, IQueryDatabaseService databaseService)
    : QueryHandlerBase<Genre>(logger, databaseService), IGenresQueryHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Genre>> SelectGenresAsync() => await SelectModelsAsync().ConfigureAwait(false);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Genre?> SelectGenreAsync(int id)
    {
        ModelParameter<Genre> parameter = new(genre => genre.GenreId, id);
        Genre? genre = await SelectModelAsync(parameter).ConfigureAwait(false);
        return genre;
    }

    #endregion
}