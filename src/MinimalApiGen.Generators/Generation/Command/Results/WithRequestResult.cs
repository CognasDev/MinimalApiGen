using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Command.Results;

/// <summary>
/// 
/// </summary>
internal sealed record WithRequestResult()
{
    #region Field Declarations

    /// <summary>
    /// 
    /// </summary>
    public required string RequestName { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string RequestFullyQualifiedName { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public List<string> PropertyNames { get; } = [];

    #endregion
}