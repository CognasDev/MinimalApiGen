using Samples.MusicCollection.Web.Albums;
using Samples.MusicCollection.Web.Sorting;

namespace Samples.MusicCollection.Web.Components.Pages;

/// <summary>
/// 
/// </summary>
/// <param name="albumsApi"></param>
public sealed partial class Albums
{
    #region Field Declarations

    private readonly IAlbumsApi _albumsApi;
    private readonly ISortingService<Album> _sortingService;

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
    /// <param name="albumsApi"></param>
    /// <param name="sortingService"></param>
    public Albums(IAlbumsApi albumsApi, ISortingService<Album> sortingService)
    {
        ArgumentNullException.ThrowIfNull(albumsApi, nameof(albumsApi));
        ArgumentNullException.ThrowIfNull(sortingService, nameof(sortingService));

        _albumsApi = albumsApi;
        _sortingService = sortingService;
    }

    #endregion

    #region Public Override Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override async Task OnInitializedAsync()
    {
        IEnumerable<Album> albums = await _albumsApi.GetAlbumsAsync().ConfigureAwait(false);
        AlbumResponses = [.. albums.OrderBy(album => album.Name)];
    }

    #endregion

    #region Private Method Declarations 

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sortKey"></param>
    private void Sort(string sortKey) => AlbumResponses = _sortingService.Sort(AlbumResponses!, sortKey);

    #endregion
}