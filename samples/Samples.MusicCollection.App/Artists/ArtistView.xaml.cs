namespace Samples.MusicCollection.App.Artists;

/// <summary>
/// 
/// </summary>
public sealed partial class ArtistView : ContentPage
{
    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="ArtistView"/>
    /// </summary>
    /// <param name="artistViewModel"></param>
    public ArtistView(ArtistViewModel artistViewModel)
    {
        InitializeComponent();
        BindingContext = artistViewModel;
    }

    #endregion
}