namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public sealed record AllMusicDetails
{
    #region Field Declarations

    private List<ArtistDetail>? _artists;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<ArtistDetail> Artists => _artists ?? [];

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artists"></param>
    public void AddArtists(IEnumerable<ArtistDetail> artists)
    {
        _artists = [.. artists];
    }

    #endregion
}