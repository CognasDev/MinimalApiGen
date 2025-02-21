using Samples.MusicCollection.App.Artists;

namespace Samples.MusicCollection.App.Navigation;

/// <summary>
/// 
/// </summary>
public interface INavigationService
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    void RegisterRoutes();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artist"></param>
    Task ToArtistViewAsync(Artist artist);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task ToArtistsViewAsync();

    #endregion
}