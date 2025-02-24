using Samples.MusicCollection.Web.Artists;
using System.Collections.Concurrent;

namespace Samples.MusicCollection.Web.Components.Pages;

/// <summary>
/// 
/// </summary>
/// <param name="artistsApi"></param>
public sealed partial class Artists
{
    #region Field Declarations

    private readonly IArtistsApi _artistsApi;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<Artist>? ArtistResponses { get; private set; }

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artistsApi"></param>
    public Artists(IArtistsApi artistsApi)
    {
        ArgumentNullException.ThrowIfNull(artistsApi, nameof(artistsApi));
        _artistsApi = artistsApi;
    }

    #endregion

    #region Public Override Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override async Task OnInitializedAsync()
    {
        IEnumerable<Artist> artists = await _artistsApi.GetArtistsAsync().ConfigureAwait(false);
        ArtistResponses = [.. artists.OrderBy(artist => artist.Name)];
    }

    #endregion
}