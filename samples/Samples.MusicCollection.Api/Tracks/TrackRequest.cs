using System.Text.Json.Serialization;

namespace Samples.MusicCollection.Api.Tracks;

/// <summary>
/// 
/// </summary>
public sealed record TrackRequest
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("trackId")]
    public required int? TrackId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("albumId")]
    public required int AlbumId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("genreId")]
    public required int GenreId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("keyId")]
    public int? KeyId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("trackNumber")]
    public required int TrackNumber { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("bpm")]
    public double? Bpm { get; init; }

    #endregion
}