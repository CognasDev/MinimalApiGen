using System.Collections.Generic;

namespace MinimalApiGen.Generators.Query.Results;

/// <summary>
/// 
/// </summary>
internal sealed record WithResponseResult()
{
    #region Field Declarations

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