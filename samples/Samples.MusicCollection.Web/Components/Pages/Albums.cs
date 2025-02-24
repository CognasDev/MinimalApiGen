using Samples.MusicCollection.Web.Albums;

namespace Samples.MusicCollection.Web.Components.Pages;

/// <summary>
/// 
/// </summary>
/// <param name="albumsApi"></param>
public sealed partial class Albums
{
    #region Field Declarations

    private readonly IAlbumsApi _albumsApi;

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
    public Albums(IAlbumsApi albumsApi)
    {
        ArgumentNullException.ThrowIfNull(albumsApi, nameof(albumsApi));
        _albumsApi = albumsApi;
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
}