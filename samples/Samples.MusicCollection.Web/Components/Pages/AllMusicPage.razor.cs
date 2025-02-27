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
    public RadzenDataGrid<Album> AlbumsGrid { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public bool IsLoading { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int ArtistsCount { get; private set; }

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
        IsLoading = true;
        await AllMusicLogic.GetArtistsAsync().ConfigureAwait(false);
        ArtistsCount = AllMusicLogic.Artists.Count();
        await InvokeAsync(ArtistsGrid.Reload).ConfigureAwait(false);
        IsLoading = false;
    }

    async void RowExpand(ArtistDetail artistDetail)
    {
        await foreach (Album albumDetail in AllMusicLogic.GetAlbumsAsync(artistDetail.ArtistId!.Value).ConfigureAwait(false))
        {
            artistDetail.AddAlbum(albumDetail);
        }
        await InvokeAsync(AlbumsGrid.Reload).ConfigureAwait(false);
    }

    #endregion
}