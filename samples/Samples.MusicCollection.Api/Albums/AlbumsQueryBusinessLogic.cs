using MinimalApiGen.Framework.BusinessLogic;
using MinimalApiGen.Framework.Data;
using MinimalApiGen.Framework.Pluralize;

namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="pluralizer"></param>
/// <param name="databaseService"></param>
public sealed class AlbumsQueryBusinessLogic(ILogger<AlbumsQueryBusinessLogic> logger, IPluralizer pluralizer, IQueryDatabaseService databaseService)
    : QueryBusinessLogicBase<Album>(logger, pluralizer, databaseService), IAlbumsQueryBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Album>> SelectAlbumsAsync() => await SelectModelsAsync().ConfigureAwait(false);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Album?> SelectAlbumAsync(int id)
    {
        Parameter parameter = new(nameof(Album.AlbumId), id);
        Album? selectedModel = await SelectModelAsync(parameter).ConfigureAwait(false);
        return selectedModel;
    }

    #endregion
}