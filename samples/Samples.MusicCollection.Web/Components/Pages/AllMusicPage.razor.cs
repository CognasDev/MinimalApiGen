using Radzen.Blazor;
using Samples.MusicCollection.Web.AllMusic;

namespace Samples.MusicCollection.Web.Components.Pages;

/// <summary>
/// 
/// </summary>
public sealed partial class AllMusicPage
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IAllMusicBusinessLogic AllMusicBusinessLogic { get; }

    #endregion

    #region Property Declarations - Front end related

    /// <summary>
    /// 
    /// </summary>
    public RadzenDataGrid<ArtistDetail> ArtistsGrid { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public RadzenDataGrid<AlbumDetail> AlbumsGrid { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public RadzenDataGrid<TrackDetail> TracksGrid { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public bool ArtistsLoading { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public bool AlbumsLoading { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public bool TracksLoading { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int ArtistsCount { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int AlbumsCount { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int TracksCount { get; private set; }

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="allMusicBusinessLogic"></param>
    public AllMusicPage(IAllMusicBusinessLogic allMusicBusinessLogic)
    {
        ArgumentNullException.ThrowIfNull(allMusicBusinessLogic, nameof(allMusicBusinessLogic));
        AllMusicBusinessLogic = allMusicBusinessLogic;
    }

    #endregion

    #region Protected Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override async Task OnInitializedAsync()
    {
        ArtistsLoading = true;
        await AllMusicBusinessLogic.GetArtistsAsync().ConfigureAwait(false);
        ArtistsCount = AllMusicBusinessLogic.Artists.Count();
        await InvokeAsync(ArtistsGrid.Reload).ConfigureAwait(false);
        ArtistsLoading = false;
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artistDetail"></param>
    /// <returns></returns>
    private async Task ArtistsGrid_RowExpand(ArtistDetail artistDetail)
    {
        AlbumsLoading = true;
        artistDetail.ClearAlbums();

        await AllMusicBusinessLogic.GetGenresAsync().ConfigureAwait(false);
        await AllMusicBusinessLogic.GetLabelsAsync().ConfigureAwait(false);
        await foreach (AlbumDetail albumDetail in AllMusicBusinessLogic.GetAlbumsAsync(artistDetail.ArtistId!.Value).ConfigureAwait(false))
        {
            artistDetail.AddAlbum(albumDetail);
        }

        AlbumsCount = artistDetail.Albums.Count();
        await InvokeAsync(AlbumsGrid.Reload).ConfigureAwait(false);
        AlbumsLoading = false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="albumDetail"></param>
    /// <returns></returns>
    private async Task AlbumsGrid_RowExpand(AlbumDetail albumDetail)
    {
        TracksLoading = true;
        albumDetail.ClearTracks();

        await AllMusicBusinessLogic.GetGenresAsync().ConfigureAwait(false);
        await AllMusicBusinessLogic.GetKeysAsync().ConfigureAwait(false);

        await foreach (TrackDetail trackDetail in AllMusicBusinessLogic.GetTracksAsync(albumDetail.AlbumId!.Value).ConfigureAwait(false))
        {
            albumDetail.AddTrack(trackDetail);
        }

        TracksCount = albumDetail.Tracks.Count();
        await InvokeAsync(TracksGrid.Reload).ConfigureAwait(false);
        TracksLoading = false;
    }

    #endregion
}