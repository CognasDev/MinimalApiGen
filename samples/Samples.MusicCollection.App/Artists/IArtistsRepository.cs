namespace Samples.MusicCollection.App.Artists;

/// <summary>
/// 
/// </summary>
public interface IArtistsRepository
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    IEnumerable<Artist> Artists { get; }

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
    Task CreateAsync(Artist artist);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artist"></param>
    /// <returns></returns>
    Task UpdateAsync(Artist artist);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artist"></param>
    /// <returns></returns>
    Task DeleteAsync(Artist artist);

    #endregion
}