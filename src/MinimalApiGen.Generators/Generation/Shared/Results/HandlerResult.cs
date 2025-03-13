using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Shared.Results;

/// <summary>
/// 
/// </summary>
internal sealed record HandlerResult
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
    public List<HandlerParamterResult> Parameters { get; } = [];

    #endregion
}