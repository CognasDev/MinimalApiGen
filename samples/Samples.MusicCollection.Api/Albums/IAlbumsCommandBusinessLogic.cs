namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
public interface IAlbumsCommandBusinessLogic
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<Album> InsertAlbumAsync(Album album);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<Album> UpdateAlbumAsync(Album album);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="album"></param>
    /// <returns></returns>
    Task DeleteAlbumAsync(Album album);

    #endregion
}