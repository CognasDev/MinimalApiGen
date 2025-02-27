namespace Samples.MusicCollection.Web.Models;

/// <summary>
/// 
/// </summary>
public sealed record Track
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public int? TrackId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required int AlbumId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required int GenreId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public int? KeyId { get; init; }

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
    public double? Bpm { get; init; }

    #endregion
}