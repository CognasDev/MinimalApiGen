namespace Samples.MusicCollection.Api.Tracks;

/// <summary>
/// 
/// </summary>
public sealed record Track
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required int? TrackId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required int AlbumId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required int GenreId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? KeyId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required int TrackNumber { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public double? Bpm { get; set; }

    #endregion
}