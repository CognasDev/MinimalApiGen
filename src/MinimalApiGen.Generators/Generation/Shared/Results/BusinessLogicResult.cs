using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Shared.Results;

/// <summary>
/// 
/// </summary>
internal sealed record BusinessLogicResult
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required string FullyQualifiedName { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string DelegateName { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public List<string> Parameters { get; } = [];

    #endregion
}