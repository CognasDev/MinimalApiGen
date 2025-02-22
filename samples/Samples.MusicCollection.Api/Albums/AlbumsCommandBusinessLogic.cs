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
public sealed class AlbumsCommandBusinessLogic(ILogger<AlbumsCommandBusinessLogic> logger, IPluralizer pluralizer, ICommandDatabaseService databaseService)
    : CommandBusinessLogicBase<Album>(logger, pluralizer, databaseService), IAlbumsCommandBusinessLogic
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
    /// <param name="album"></param>
    /// <returns></returns>
    public async Task DeleteAlbumAsync(Album album)
    {
        Parameter parameter = new(nameof(Album.AlbumId), album.AlbumId);
        await DeleteModelAsync(parameter).ConfigureAwait(false);
    }

    #endregion
}