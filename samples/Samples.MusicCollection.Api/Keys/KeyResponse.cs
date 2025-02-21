using System.Text.Json.Serialization;

namespace Samples.MusicCollection.Api.Keys;

/// <summary>
/// 
/// </summary>
public sealed record KeyResponse
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("keyId")]
    public required int KeyId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("camelotCode")]
    public required string CamelotCode { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    #endregion
}