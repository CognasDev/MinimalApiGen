using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Shared.Results;

/// <summary>
/// 
/// </summary>
internal sealed record WithResponseResult
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required string ResponseName { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string ResponseFullyQualifiedName { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public List<string> PropertyNames { get; } = [];

    #endregion
}