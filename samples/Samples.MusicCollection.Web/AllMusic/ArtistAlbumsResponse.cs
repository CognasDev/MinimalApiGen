namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public sealed record ArtistAlbumsResponse
{
    #region Field Declarations

    private List<ArtistAlbumResponse>? _albumResponses;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<ArtistAlbumResponse> Albums => _albumResponses ?? [];

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="albumResponses"></param>
    public void AddAlbums(IEnumerable<ArtistAlbumResponse> albumResponses)
    {
        _albumResponses = [.. albumResponses];
    }

    #endregion
}