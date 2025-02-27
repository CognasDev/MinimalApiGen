namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
public interface IAlbumsQueryBusinessLogic
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artistId"></param>
    /// <returns></returns>
    Task<IEnumerable<Album>> SelectAlbumsAsync(int? artistId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Album?> SelectAlbumAsync(int id);

    #endregion
}