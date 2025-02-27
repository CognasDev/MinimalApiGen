using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Shared.Results;

/// <summary>
/// 
/// </summary>
internal sealed record BusinessLogicParamterResult
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