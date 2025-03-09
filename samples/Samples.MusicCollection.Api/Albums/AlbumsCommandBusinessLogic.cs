using MinimalApiGen.Framework.BusinessLogic;
using MinimalApiGen.Framework.Data;
using MinimalApiGen.Framework.Pluralize;

namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="databaseService"></param>
public sealed class AlbumsCommandBusinessLogic(ILogger<AlbumsCommandBusinessLogic> logger, ICommandDatabaseService databaseService)
    : CommandBusinessLogicBase<Album>(logger, databaseService), IAlbumsCommandBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Album> InsertAlbumAsync(Album album) => await InsertModelAsync(album).ConfigureAwait(false);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Album> UpdateAlbumAsync(Album album) => await UpdateModelAsync(album).ConfigureAwait(false);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteAlbumAsync(int id)
    {
        ModelParameter<Album> parameter = new(album => album.AlbumId, id);
        await DeleteModelAsync(parameter).ConfigureAwait(false);
    }

    #endregion
}