using MinimalApiGen.Framework.BusinessLogic;
using MinimalApiGen.Framework.Data;
using MinimalApiGen.Framework.Pluralize;

namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="databaseService"></param>
public sealed class GenresQueryBusinessLogic(ILogger<GenresQueryBusinessLogic> logger, IQueryDatabaseService databaseService)
    : QueryBusinessLogicBase<Genre>(logger, databaseService), IGenresQueryBusinessLogic
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