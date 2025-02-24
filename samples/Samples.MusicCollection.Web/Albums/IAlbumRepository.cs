namespace Samples.MusicCollection.Web.Albums;

/// <summary>
/// 
/// </summary>
public interface IAlbumRepository
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Album>> GetAlbumsAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="album"></param>
    /// <returns></returns>
    Task<IEnumerable<Album>> InsertAlbumAsync(Album album);

    #endregion
}