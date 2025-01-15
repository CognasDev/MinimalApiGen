using MinimalApiGen.Generators.Generation.Command.Results;
using MinimalApiGen.Generators.Generation.Shared.Results;
using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Query.Results;

/// <summary>
/// 
/// </summary>
internal sealed record QueryIntermediateResult
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
    public required QueryType QueryType { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public List<string> ModelProperties { get; } = [];

    /// <summary>
    /// 
    /// </summary>
    public string? QueryNamespace { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ModelIdPropertyResult ModelIdPropertyResult { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public WithResponseResult? ResponseResult { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? CachedFor { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public BusinessLogicResult? BusinessLogicResult { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<string> Services { get; } = [];

    /// <summary>
    /// 
    /// </summary>
    public Dictionary<string, string> KeyedServices { get; } = [];

    /// <summary>
    /// 
    /// </summary>
    public int Version { get; set; } = 1;

    /// <summary>
    /// 
    /// </summary>
    public bool WithPagination { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public bool WithMappingService { get; set; }

    #endregion
}