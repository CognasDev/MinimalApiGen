namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
public interface IAlbumsQueryBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Album>> SelectAlbumsAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Album?> SelectAlbumAsync(int id);

    #endregion
}