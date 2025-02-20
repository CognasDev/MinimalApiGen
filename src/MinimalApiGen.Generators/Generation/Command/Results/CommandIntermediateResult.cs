using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.Results;
using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Command.Results;

/// <summary>
/// 
/// </summary>
internal sealed record CommandIntermediateResult
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
    public required OperationType CommandType { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public List<string> ModelProperties { get; } = [];

    /// <summary>
    /// 
    /// </summary>
    public ModelIdPropertyResult ModelIdPropertyResult { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? CommandNamespace { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public WithRequestResult RequestResult { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public WithResponseResult? ResponseResult { get; set; }

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
    public bool WithRequestMappingService { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public bool WithResponseMappingService { get; set; }

    #endregion
}