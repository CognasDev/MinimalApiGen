using Samples.MusicCollection.Web.AllMusic;

namespace Samples.MusicCollection.Web.Components.Pages;

/// <summary>
/// 
/// </summary>
public sealed partial class AllMusicPage
{
    #region Field Declarations


    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IAllMusicLogic AllMusicLogic { get; }

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
    }

    #endregion

    #region Private Method Declarations
    #endregion
}