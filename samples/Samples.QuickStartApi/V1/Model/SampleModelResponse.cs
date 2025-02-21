namespace Samples.QuickStartApi.V1.Model;

/// <summary>
/// 
/// </summary>
public sealed record SampleModelResponse
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required int? Id { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string? Name { get; init; }

    #endregion
}