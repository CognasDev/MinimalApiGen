using Radzen.Blazor;
using Samples.MusicCollection.Web.Models;

namespace Samples.MusicCollection.Web.Components.Pages;

/// <summary>
/// 
/// </summary>
public sealed partial class AlbumsPage
{
    #region Field Declarations

    private readonly IRepository<Album> _albumsRepository;
    private RadzenDataGrid<Album>? _dataGrid;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<Album>? Albums { get; private set; }

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="albumsRepository"></param>
    public AlbumsPage(IRepository<Album> albumsRepository)
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
        IEnumerable<Album> albums = await _albumsRepository.GetAsync().ConfigureAwait(false);
        Albums = [.. albums.OrderBy(album => album.Name)];
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
        await _albumsRepository.InsertAsync(album).ConfigureAwait(false);
        await InvokeAsync(_dataGrid!.Reload).ConfigureAwait(false);
    }

    #endregion
}