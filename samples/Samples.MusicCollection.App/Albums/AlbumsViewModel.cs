using Cognas.MaulTools.Shared.Commands;
using Cognas.MaulTools.Shared.Mvvm;
using Cognas.Tools.Shared.Extensions;
using Samples.MusicCollection.App.Artists;
using System.Windows.Input;

namespace Samples.MusicCollection.App.Albums;

/// <summary>
/// 
/// </summary>
public sealed class AlbumsViewModel : ViewModelBase, IQueryAttributable
{
    #region Field Declarations

    private ICommand? _initiateCommand;
    private ICommand? _viewAlbumCommand;
    private Artist _artist = null!;
    private IEnumerable<Album> _albums = null!;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IAlbumsRepository AlbumsRepository { get; }

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
    public IEnumerable<Album> Albums
    {
        get => _albums;
        private set => SetProperty(ref _albums, value);
    }

    #endregion

    #region Command Declarations

    /// <summary>
    /// 
    /// </summary>
    public ICommand InitiateCommand =>
        _initiateCommand ??= new DelegateCommand(async () => await InitiateExecuteAsync().ConfigureAwait(false));

    #endregion

    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="AlbumsViewModel"/>
    /// </summary>
    /// <param name="albumsRepository"></param>
    public AlbumsViewModel(IAlbumsRepository albumsRepository)
    {
        ArgumentNullException.ThrowIfNull(albumsRepository, nameof(albumsRepository));
        AlbumsRepository = albumsRepository;
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
    private async Task InitiateExecuteAsync()
    {
        await AlbumsRepository.InitiateAsync().ConfigureAwait(false);
        GetAlbumsByArtist();
    }

    /// <summary>
    /// 
    /// </summary>
    private void GetAlbumsByArtist()
    {
        List<Album> albums = [];
        AlbumsRepository.Albums.FastForEach(album =>
        {
            if (album.ArtistId == Artist.ArtistId)
            {
                albums.Add(album);
            }
        });
        Albums = albums;
    }

    #endregion
}