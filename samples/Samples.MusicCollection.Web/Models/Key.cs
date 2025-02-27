namespace Samples.MusicCollection.Web.Models;

/// <summary>
/// 
/// </summary>
public sealed record Key
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required int KeyId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string CamelotCode { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; init; }

    #endregion
}