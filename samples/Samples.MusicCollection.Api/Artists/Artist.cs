namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
public sealed record Artist
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required int? ArtistId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; set; }

    #endregion
}