using Samples.MusicCollection.Web.Albums;
using System.Collections.Concurrent;

namespace Samples.MusicCollection.Web.Components.Pages;

/// <summary>
/// 
/// </summary>
/// <param name="albumsApi"></param>
public sealed partial class Albums(IAlbumsApi albumsApi)
{
    #region Field Declarations

    private readonly IAlbumsApi _albumsApi = albumsApi;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<AlbumResponse>? AlbumResponses { get; private set; }

    #endregion

    #region Public Override Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override async Task OnInitializedAsync()
    {
        IEnumerable<AlbumResponse> albums = await _albumsApi.GetAlbumsAsync().ConfigureAwait(false);
        AlbumResponses = [.. albums.OrderBy(album => album.Name)];
    }

    #endregion
}