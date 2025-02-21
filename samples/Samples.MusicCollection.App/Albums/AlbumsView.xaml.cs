namespace Samples.MusicCollection.App.Albums;

/// <summary>
/// 
/// </summary>
public sealed partial class AlbumsView : ContentPage
{
    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="AlbumsView"/>
    /// </summary>
    /// <param name="albumsViewModel"></param>
    public AlbumsView(AlbumsViewModel albumsViewModel)
    {
        InitializeComponent();
        BindingContext = albumsViewModel;
    }

    #endregion
}