using MinimalApiGen.Generators.Equality;

namespace MinimalApiGen.Generators.Generation.Command.Results;

/// <summary>
/// 
/// </summary>
internal readonly record struct CommandResult
{
    #region Property Declarations - Model Details

    /// <summary>
    /// 
    /// </summary>
    public string ClassName { get; }

    /// <summary>
    /// 
    /// </summary>
    public string ClassNamespace { get; }

    /// <summary>
    /// 
    /// </summary>
    public string ModelName { get; }

    /// <summary>
    /// 
    /// </summary>
    public string ModelPluralName { get; }

    /// <summary>
    /// 
    /// </summary>
    public string ModelFullyQualifiedName { get; }

    /// <summary>
    /// 
    /// </summary>
    public CommandType CommandType { get; }

    /// <summary>
    /// 
    /// </summary>
    public EquatableArray<string> ModelProperties { get; }

    #endregion

    #region Property Declarations - Response Details

    /// <summary>
    /// 
    /// </summary>
    public string ResponseName { get; }

    /// <summary>
    /// 
    /// </summary>
    public string ResponseFullyQualifiedName { get; }

    /// <summary>
    /// 
    /// </summary>
    public bool WithRequestMappingService { get; }

    /// <summary>
    /// 
    /// </summary>
    public bool WithResponseMappingService { get; }

    /// <summary>
    /// 
    /// </summary>
    public EquatableArray<string> RequestProperties { get; }

    /// <summary>
    /// 
    /// </summary>
    public EquatableArray<string> ResponseProperties { get; }

    #endregion

    #region Property Declarations - Service Details

    /// <summary>
    /// 
    /// </summary>
    public EquatableArray<string> Services { get; }

    /// <summary>
    /// 
    /// </summary>
    public int Version { get; }

    /// <summary>
    /// 
    /// </summary>
    public EquatableDictionary<string, string> KeyedServices { get; }

    #endregion

    #region Property Declarations - Business Logic Details

    /// <summary>
    /// 
    /// </summary>
    public string BusinessLogicFullyQualifiedName { get; }

    /// <summary>
    /// 
    /// </summary>
    public string BusinessLogicDelegateName { get; }

    /// <summary>
    /// 
    /// </summary>
    public EquatableArray<string> BusinessLogicParameters { get; }

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="CommandIntermediateResult"></param>
    public CommandResult(CommandIntermediateResult CommandIntermediateResult)
    {
        ClassName = $"{CommandIntermediateResult.ModelName}CommandRouteEndpointsMapper";
        ClassNamespace = CommandIntermediateResult.CommandNamespace!;
        ModelName = CommandIntermediateResult.ModelName;
        ModelPluralName = CommandIntermediateResult.ModelPluralName;
        ModelFullyQualifiedName = CommandIntermediateResult.ModelFullyQualifiedName;
        ModelProperties = new(CommandIntermediateResult.ModelProperties);
        CommandType = CommandIntermediateResult.CommandType;

        ResponseName = CommandIntermediateResult.ResponseResult!.ResponseName;
        ResponseFullyQualifiedName = CommandIntermediateResult.ResponseResult!.ResponseFullyQualifiedName;
        WithRequestMappingService = CommandIntermediateResult.WithRequestMappingService;
        WithResponseMappingService = CommandIntermediateResult.WithResponseMappingService;
        RequestProperties = new(CommandIntermediateResult.RequestResult.PropertyNames);
        ResponseProperties = new(CommandIntermediateResult.ResponseResult.PropertyNames);

        Services = new(CommandIntermediateResult.Services);
        Version = CommandIntermediateResult.Version;
        KeyedServices = new(CommandIntermediateResult.KeyedServices);

        BusinessLogicFullyQualifiedName = CommandIntermediateResult.BusinessLogicResult!.FullyQualifiedName;
        BusinessLogicDelegateName = CommandIntermediateResult.BusinessLogicResult!.DelegateName;
        BusinessLogicParameters = new(CommandIntermediateResult.BusinessLogicResult!.Parameters);
    }

    #endregion
}