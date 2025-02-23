namespace Samples.MusicCollection.Web.Artists;

/// <summary>
/// 
/// </summary>
public sealed record ArtistRequest
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