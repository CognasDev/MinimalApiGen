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
    public IAllMusicHandler AllMusicHandler { get; }

    #endregion

    #region Property Declarations - Front end related

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
    /// <param name="allMusicHandler"></param>
    public AllMusicPage(IAllMusicHandler allMusicHandler)
    {
        ArgumentNullException.ThrowIfNull(allMusicHandler, nameof(allMusicHandler));
        AllMusicHandler = allMusicHandler;
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
        await AllMusicHandler.GetArtistsAsync().ConfigureAwait(false);
        ArtistsCount = AllMusicHandler.Artists.Count();
        ArtistsLoading = false;
    }

    #endregion


}