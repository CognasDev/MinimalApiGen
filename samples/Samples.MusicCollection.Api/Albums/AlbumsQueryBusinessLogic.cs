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
    /// <param name="artistId"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Album>> SelectAlbumsAsync(int? artistId)
    {
        IEnumerable<Album> selectedModels;
        if (artistId.HasValue)
        {
            Parameter artistIdParameter = new(nameof(Album.ArtistId), artistId);
            string storedProcedueName = $"[dbo].[{PluralModelName}_SelectByArtistId]";
            selectedModels = await SelectModelsAsync(storedProcedueName, artistIdParameter).ConfigureAwait(false);
        }
        else
        {
            selectedModels = await SelectModelsAsync().ConfigureAwait(false);
        }
        return selectedModels;
    }

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