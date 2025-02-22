namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
public sealed record Album
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required int? AlbumId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required int ArtistId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? GenreId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required int LabelId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required DateTime ReleaseDate { get; set; }

    #endregion
}