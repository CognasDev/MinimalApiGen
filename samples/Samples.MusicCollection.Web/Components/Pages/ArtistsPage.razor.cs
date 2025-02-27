using Radzen.Blazor;
using Samples.MusicCollection.Web.AllMusic;

namespace Samples.MusicCollection.Web.Components.Pages;

/// <summary>
/// 
/// </summary>
public sealed partial class ArtistsPage
{
    #region Field Declarations

    private readonly IAllMusicLogic _allMusicLogic;
    private RadzenDataGrid<ArtistDetail>? _dataGrid;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<ArtistDetail>? Artists { get; private set; }

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="allMusicLogic"></param>
    public ArtistsPage(IAllMusicLogic allMusicLogic)
    {
        ArgumentNullException.ThrowIfNull(allMusicLogic, nameof(allMusicLogic));
        _allMusicLogic = allMusicLogic;
    }

    #endregion

    #region Protected Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override async Task OnInitializedAsync()
    {
        await _allMusicLogic.GetArtistsAsync().ConfigureAwait(false);
        Artists = _allMusicLogic.Artists.OrderBy(artist => artist.Name);
    }

    #endregion

    #region Private Method Declarations
    #endregion
}