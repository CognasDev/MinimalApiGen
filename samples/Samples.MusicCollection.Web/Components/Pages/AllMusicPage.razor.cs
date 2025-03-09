using Radzen;
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
        ArtistsLoading = false;
    }

    #endregion

    #region Private Method Declarations

    void CompleteUpload(UploadCompleteEventArgs args)
    {
        var d = 3;
    }

    #endregion
}