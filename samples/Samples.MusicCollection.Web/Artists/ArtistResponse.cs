namespace Samples.MusicCollection.Web.Artists;

/// <summary>
/// 
/// </summary>
public sealed record ArtistResponse
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required int ArtistId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; init; }

    #endregion
}