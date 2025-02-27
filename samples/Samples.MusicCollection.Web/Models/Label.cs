namespace Samples.MusicCollection.Web.Models;

/// <summary>
/// 
/// </summary>
public sealed record Label
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public int? LabelId { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; init; }

    #endregion
}