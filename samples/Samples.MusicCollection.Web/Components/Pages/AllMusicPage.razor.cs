using Radzen;
using Radzen.Blazor;
using Samples.MusicCollection.Web.AllMusic;
using Samples.MusicCollection.Web.Api;
using Samples.MusicCollection.Web.Models;
using System.Threading;

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
    public IAllMusicLogic AllMusicLogic { get; }

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
    /// <param name="allMusicLogic"></param>
    public AllMusicPage(IAllMusicLogic allMusicLogic)
    {
        ArgumentNullException.ThrowIfNull(allMusicLogic, nameof(allMusicLogic));
        AllMusicLogic = allMusicLogic;
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
        await AllMusicLogic.GetArtistsAsync().ConfigureAwait(false);
        ArtistsCount = AllMusicLogic.Artists.Count();
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
        if (!AllMusicLogic.Genres.Any())
        {
            await AllMusicLogic.GetGenresAsync().ConfigureAwait(false);
        }
        if (!AllMusicLogic.Keys.Any())
        {
            await AllMusicLogic.GetKeysAsync().ConfigureAwait(false);
        }
        if (!artistDetail.HasAlbums)
        {
            artistDetail.ClearAlbums();
            await foreach (AlbumDetail albumDetail in AllMusicLogic.GetAlbumsAsync(artistDetail.ArtistId!.Value).ConfigureAwait(false))
            {
                artistDetail.AddAlbum(albumDetail);
            }
            AlbumsCount = artistDetail.Albums.Count();
            await InvokeAsync(AlbumsGrid.Reload).ConfigureAwait(false);
        }
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
        if (!albumDetail.HasTracks)
        {
            albumDetail.ClearTracks();
            await AllMusicLogic.GetGenresAsync().ConfigureAwait(false);
            await foreach (TrackDetail trackDetail in AllMusicLogic.GetTracksAsync(albumDetail.AlbumId!.Value).ConfigureAwait(false))
            {
                albumDetail.AddTrack(trackDetail);
            }
            TracksCount = albumDetail.Tracks.Count();
            await InvokeAsync(TracksGrid.Reload).ConfigureAwait(false);
        }
        TracksLoading = false;
    }

    #endregion
}