namespace Samples.MusicCollection.App.Albums;

/// <summary>
/// 
/// </summary>
public interface IAlbumsRepository
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    IEnumerable<Album> Albums { get; }

    #endregion

    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task InitiateAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artist"></param>
    /// <returns></returns>
    Task CreateAsync(Album artist);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artist"></param>
    /// <returns></returns>
    Task UpdateAsync(Album artist);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artist"></param>
    /// <returns></returns>
    Task DeleteAsync(Album artist);

    #endregion
}