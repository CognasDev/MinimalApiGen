namespace Samples.MusicCollection.Web.Artists;

/// <summary>
/// 
/// </summary>
public interface IArtistsApi
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<ArtistResponse>> GetArtistsAsync();

    #endregion
}