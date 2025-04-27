using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Shared.Results;

/// <summary>
/// 
/// </summary>
internal sealed record AddEndpointFilterResult
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required string FilterName { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string FilterFullyQualifiedName { get; init; }

    #endregion
}