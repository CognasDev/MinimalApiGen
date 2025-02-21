using Samples.MusicCollection.App.Artists;

namespace Samples.MusicCollection.App.Navigation;

/// <summary>
/// 
/// </summary>
public sealed class NavigationService : INavigationService
{
    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="NavigationService"/>
    /// </summary>
    public NavigationService()
    {
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    public void RegisterRoutes()
    {
        Routing.RegisterRoute(nameof(ArtistView), typeof(ArtistView));
        Routing.RegisterRoute(nameof(ArtistsView), typeof(ArtistsView));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artist"></param>
    public async Task ToArtistViewAsync(Artist artist)
    {
        Dictionary<string, object> parameters = new(1) { [nameof(Artist)] = artist };
        await Shell.Current.GoToAsync(nameof(ArtistView), true, parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// 
    /// </summary>
    public async Task ToArtistsViewAsync()
    {
        await Shell.Current.GoToAsync(nameof(ArtistsView), true).ConfigureAwait(false);
    }

    #endregion
}