namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
public interface IAlbumsCommandHandler
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
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteAlbumAsync(int id);

    #endregion
}