using Samples.MusicCollection.Web.Models;

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
    public required int TrackNumber { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Genre? Genre { get; set; }

    /// <summary>
    /// 
    /// </summary>

    public required double? Bpm { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Key? Key { get; set; }

    #endregion
}