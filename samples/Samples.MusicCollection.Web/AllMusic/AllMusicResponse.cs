namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public sealed record AllMusicResponse
{
    #region Field Declarations

    private List<ArtistAlbumsResponse>? _artistResponses;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<ArtistAlbumsResponse> Artists => _artistResponses ?? [];

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artistResponses"></param>
    public void AddArtists(IEnumerable<ArtistAlbumsResponse> artistResponses)
    {
        _artistResponses = [.. artistResponses];
    }

    #endregion
}