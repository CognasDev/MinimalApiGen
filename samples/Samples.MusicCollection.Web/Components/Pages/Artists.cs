using Samples.MusicCollection.Web.Artists;
using System.Collections.Concurrent;

namespace Samples.MusicCollection.Web.Components.Pages;

/// <summary>
/// 
/// </summary>
/// <param name="artistsApi"></param>
public sealed partial class Artists(IArtistsApi artistsApi)
{
    #region Field Declarations

    private readonly IArtistsApi _artistsApi = artistsApi;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<ArtistResponse>? ArtistResponses { get; private set; }

    #endregion

    #region Public Override Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override async Task OnInitializedAsync()
    {
        IEnumerable<ArtistResponse> artists = await _artistsApi.GetArtistsAsync().ConfigureAwait(false);
        ArtistResponses = [.. artists.OrderBy(artist => artist.Name)];
    }

    #endregion
}