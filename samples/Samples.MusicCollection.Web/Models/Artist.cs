namespace Samples.MusicCollection.Web.Models;

/// <summary>
/// 
/// </summary>
public sealed record Artist
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public int? ArtistId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; init; }

    #endregion
}