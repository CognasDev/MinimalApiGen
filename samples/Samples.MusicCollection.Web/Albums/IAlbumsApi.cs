namespace Samples.MusicCollection.Web.Albums;

/// <summary>
/// 
/// </summary>
public interface IAlbumsApi
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<AlbumResponse>> GetAlbumsAsync();

    #endregion
}