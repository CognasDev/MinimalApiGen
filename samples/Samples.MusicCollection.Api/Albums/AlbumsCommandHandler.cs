using MinimalApiGen.Framework.ApiHandlers;
using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="databaseService"></param>
public sealed class AlbumsCommandHandler(ILogger<AlbumsCommandHandler> logger, ICommandDatabaseService databaseService)
    : CommandHandlerBase<Album>(logger, databaseService), IAlbumsCommandHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Album> InsertAlbumAsync(Album album) => await InsertModelAsync(album);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Album> UpdateAlbumAsync(Album album) => await UpdateModelAsync(album);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteAlbumAsync(int id)
    {
        ModelParameter<Album> parameter = new(album => album.AlbumId, id);
        await DeleteModelAsync(parameter);
    }

    #endregion
}