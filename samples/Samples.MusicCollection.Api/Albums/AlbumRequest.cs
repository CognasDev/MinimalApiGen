using System.Text.Json.Serialization;

namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
public sealed record AlbumRequest
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("albumId")]
    public int? AlbumId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("artistId")]
    public required int ArtistId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("genreId")]
    public int? GenreId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("labelId")]
    public required int LabelId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("releaseDate")]
    public required DateTime ReleaseDate { get; init; }

    #endregion
}