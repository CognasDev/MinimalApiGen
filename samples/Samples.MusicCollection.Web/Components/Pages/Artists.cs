using Samples.MusicCollection.Web.Artists;
using Samples.MusicCollection.Web.Sorting;
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
    private readonly ISortingService<Artist> _sortingService;

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
    /// <param name="sortingService"></param>
    public Artists(IArtistsApi artistsApi, ISortingService<Artist> sortingService)
    {
        ArgumentNullException.ThrowIfNull(artistsApi, nameof(artistsApi));
        ArgumentNullException.ThrowIfNull(sortingService, nameof(sortingService));

        _artistsApi = artistsApi;
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
        IEnumerable<Artist> artists = await _artistsApi.GetArtistsAsync().ConfigureAwait(false);
        ArtistResponses = [.. artists.OrderBy(artist => artist.Name)];
    }

    #endregion

    #region Private Method Declarations 

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sortKey"></param>
    private void Sort(string sortKey) => ArtistResponses = _sortingService.Sort(ArtistResponses!, sortKey);

    #endregion
}