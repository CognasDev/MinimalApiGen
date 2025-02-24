using Radzen.Blazor;
using Samples.MusicCollection.Web.Albums;

namespace Samples.MusicCollection.Web.Components.Pages;

/// <summary>
/// 
/// </summary>
/// <param name="albumsApi"></param>
public sealed partial class Albums
{
    #region Field Declarations

    private readonly IAlbumRepository _albumsRepository;
    private RadzenDataGrid<Album>? _dataGrid;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<Album>? AlbumResponses { get; private set; }

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="albumsRepository"></param>
    public Albums(IAlbumRepository albumsRepository)
    {
        ArgumentNullException.ThrowIfNull(albumsRepository, nameof(albumsRepository));
        _albumsRepository = albumsRepository;
    }

    #endregion

    #region Protected Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override async Task OnInitializedAsync()
    {
        IEnumerable<Album> albums = await _albumsRepository.GetAlbumsAsync().ConfigureAwait(false);
        AlbumResponses = [.. albums.OrderBy(album => album.Name)];
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private async Task NewAlbumAsync()
    {
        Album album = new()
        {
            ArtistId = 1,
            GenreId = 1,
            LabelId = 1,
            Name = Guid.NewGuid().ToString(),
            ReleaseDate = DateTime.Now
        };
        await _albumsRepository.InsertAlbumAsync(album).ConfigureAwait(false);
        await InvokeAsync(_dataGrid!.Reload).ConfigureAwait(false);
    }

    #endregion
}