namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public sealed record ArtistAlbumResponse
{
    #region Field Declarations

    private List<AlbumTrackResponse>? _trackResponses;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public string? Genre { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string Label { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required DateTime ReleaseDate { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<AlbumTrackResponse> Tracks => _trackResponses ?? [];

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="trackResponses"></param>
    public void AddTracks(IEnumerable<AlbumTrackResponse> trackResponses)
    {
        _trackResponses = [.. trackResponses];
    }

    #endregion
}