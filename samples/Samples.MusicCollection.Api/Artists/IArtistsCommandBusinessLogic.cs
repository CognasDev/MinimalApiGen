namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
public interface IArtistsCommandBusinessLogic
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<Artist> InsertArtistAsync(Artist album);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<Artist> UpdateArtistAsync(Artist album);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteArtistAsync(int id);

    #endregion
}