using System.Text.Json.Serialization;

namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
public sealed record ArtistResponse
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("artistId")]
    public required int? ArtistId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    #endregion
}