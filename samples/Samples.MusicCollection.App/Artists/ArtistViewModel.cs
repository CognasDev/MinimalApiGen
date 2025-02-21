using Cognas.MaulTools.Shared.Commands;
using Cognas.MaulTools.Shared.Mvvm;
using Samples.MusicCollection.App.Albums;
using Samples.MusicCollection.App.Navigation;
using System.Windows.Input;

namespace Samples.MusicCollection.App.Artists;

/// <summary>
/// 
/// </summary>
public sealed class ArtistViewModel : ViewModelBase, IQueryAttributable
{
    #region Field Declarations

    private readonly INavigationService _navigationService;

    private ICommand? _viewArtistCommand;
    private Artist _artist = null!;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public Artist Artist
    {
        get => _artist;
        set => SetProperty(ref _artist, value);
    }

    /// <summary>
    /// 
    /// </summary>
    public AlbumsView Albums { get; }

    #endregion

    #region Command Declarations

    /// <summary>
    /// 
    /// </summary>
    public ICommand ViewArtistsCommand =>
        _viewArtistCommand ??= new DelegateCommand(async () => await ViewArtistsExecuteAsync().ConfigureAwait(false));

    #endregion

    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="ArtistViewModel"/>
    /// </summary>
    /// <param name="navigationService"></param>
    public ArtistViewModel(INavigationService navigationService, AlbumsView albumsView)
    {
        ArgumentNullException.ThrowIfNull(navigationService, nameof(navigationService));
        _navigationService = navigationService;
        Albums = albumsView;
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Artist = (Artist)query[nameof(Artist)];
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private async Task ViewArtistsExecuteAsync()
    {
        await _navigationService.ToArtistsViewAsync().ConfigureAwait(false);
    }

    #endregion
}