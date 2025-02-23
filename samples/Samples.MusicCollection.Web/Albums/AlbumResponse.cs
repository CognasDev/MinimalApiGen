namespace Samples.MusicCollection.Web.Albums;

/// <summary>
/// 
/// </summary>
public sealed record AlbumResponse
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required int AlbumId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required int ArtistId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public int? GenreId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required int LabelId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required DateTime ReleaseDate { get; init; }

    #endregion
}