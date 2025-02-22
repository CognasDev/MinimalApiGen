namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
public sealed record Genre
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required int? GenreId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; set; }

    #endregion
}