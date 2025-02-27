using MinimalApiGen.Framework.BusinessLogic;
using MinimalApiGen.Framework.Data;
using MinimalApiGen.Framework.Pluralize;

namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="pluralizer"></param>
/// <param name="databaseService"></param>
public sealed class GenresCommandBusinessLogic(ILogger<GenresCommandBusinessLogic> logger, IPluralizer pluralizer, ICommandDatabaseService databaseService)
    : CommandBusinessLogicBase<Genre>(logger, pluralizer, databaseService), IGenresCommandBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Genre> InsertGenreAsync(Genre album) => await InsertModelAsync(album).ConfigureAwait(false);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Genre> UpdateGenreAsync(Genre album) => await UpdateModelAsync(album).ConfigureAwait(false);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteGenreAsync(int id)
    {
        ModelParameter<Genre> parameter = new(genre => genre.GenreId, id);
        await DeleteModelAsync(parameter).ConfigureAwait(false);
    }

    #endregion
}