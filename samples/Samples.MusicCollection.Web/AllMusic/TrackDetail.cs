namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public sealed record TrackDetail
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public int? TrackId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? TrackNumber { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? GenreId { get; set; }

    /// <summary>
    /// 
    /// </summary>

    public double? Bpm { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? KeyId { get; set; }

    #endregion
}