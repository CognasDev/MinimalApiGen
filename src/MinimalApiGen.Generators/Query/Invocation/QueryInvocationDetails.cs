using System.Collections.Generic;

namespace MinimalApiGen.Generators.Query.Invocation;

/// <summary>
/// 
/// </summary>
internal sealed record QueryInvocationDetails()
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required string ModelName { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string ModelPluralName { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string ModelFullyQualifiedName { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public List<string> PropertyNames { get; } = [];

    #endregion
}