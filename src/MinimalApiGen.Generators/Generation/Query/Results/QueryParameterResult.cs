namespace MinimalApiGen.Generators.Generation.Query.Results;

/// <summary>
/// 
/// </summary>
internal sealed record QueryParameterResult
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string Type { get; init; }

    #endregion
}