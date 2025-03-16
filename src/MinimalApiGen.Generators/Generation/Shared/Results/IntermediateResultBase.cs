using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Shared.Results;

/// <summary>
/// 
/// </summary>
internal abstract record IntermediateResultBase
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
    public required OperationType OperationType { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public List<string> ModelProperties { get; } = [];

    /// <summary>
    /// 
    /// </summary>
    public string? Namespace { get; set; }

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
    public HandlerResult? HandlerResult { get; set; }

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
    public bool WithResponseMappingService { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public bool WithJwtAuthentication { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? AuthenticationRole { get; set; }

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    protected IntermediateResultBase()
    {
    }

    #endregion
}