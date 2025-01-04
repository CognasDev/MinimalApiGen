namespace MinimalApiGen.Generators.Query.Results;

/// <summary>
/// 
/// </summary>
internal sealed record EndpointRouteMappingResult
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required string ClassNamespace { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string ClassName { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required int Version { get; init; }

    #endregion
}