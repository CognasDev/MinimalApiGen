namespace Samples.MusicCollection.Web.Models;

/// <summary>
/// 
/// </summary>
public sealed record Genre
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public int? GenreId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; init; }

    #endregion
}