namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
public interface IArtistsQueryHandler
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Artist>> SelectArtistsAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Artist?> SelectArtistAsync(int id);

    #endregion
}