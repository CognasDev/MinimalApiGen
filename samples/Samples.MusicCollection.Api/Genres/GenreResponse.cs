using System.Text.Json.Serialization;

namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
public sealed record GenreResponse
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("genreId")]
    public required int GenreId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    #endregion
}