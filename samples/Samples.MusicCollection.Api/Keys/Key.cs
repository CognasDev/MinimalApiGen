namespace Samples.MusicCollection.Api.Keys;

/// <summary>
/// 
/// </summary>
public sealed record Key
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required int KeyId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string CamelotCode { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; set; }

    #endregion
}