namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public sealed record AlbumTrackResponse
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required int TrackNumber { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string Genre { get; init; }

    /// <summary>
    /// 
    /// </summary>

    public required double? Bpm { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public string? CamelotCode { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public string? Key { get; init; }

    #endregion
}