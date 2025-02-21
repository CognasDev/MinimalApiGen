namespace Samples.MusicCollection.App.Artists;

/// <summary>
/// 
/// </summary>
public sealed partial class ArtistsView : ContentPage
{
    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="ArtistsView"/>
    /// </summary>
    /// <param name="artistsViewModel"></param>
    public ArtistsView(ArtistsViewModel artistsViewModel)
    {
        InitializeComponent();
        BindingContext = artistsViewModel;
    }

    #endregion
}