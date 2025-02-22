namespace Samples.MusicCollection.Api.Labels;

/// <summary>
/// 
/// </summary>
public sealed record Label
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required int? LabelId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; set; }

    #endregion
}