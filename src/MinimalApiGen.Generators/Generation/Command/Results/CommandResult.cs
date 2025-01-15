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

    /// <summary>
    /// 
    /// </summary>
    public string ModelIdPropertyName { get; }

    /// <summary>
    /// 
    /// </summary>
    public string ModelIdPropertyType { get; }

    /// <summary>
    /// 
    /// </summary>
    public string? ModelIdUnderlyingPropertyType { get; }

    #endregion

    #region Property Declarations - Request Details

    /// <summary>
    /// 
    /// </summary>
    public string RequestName { get; }

    /// <summary>
    /// 
    /// </summary>
    public string RequestFullyQualifiedName { get; }

    /// <summary>
    /// 
    /// </summary>
    public bool WithRequestMappingService { get; }

    /// <summary>
    /// 
    /// </summary>
    public EquatableArray<string> RequestProperties { get; }

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
    public bool WithResponseMappingService { get; }

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
    /// <param name="commandIntermediateResult"></param>
    public CommandResult(CommandIntermediateResult commandIntermediateResult)
    {
        ClassName = $"{commandIntermediateResult.ModelName}CommandRouteEndpointsMapper";
        ClassNamespace = commandIntermediateResult.CommandNamespace!;
        ModelName = commandIntermediateResult.ModelName;
        ModelPluralName = commandIntermediateResult.ModelPluralName;
        ModelFullyQualifiedName = commandIntermediateResult.ModelFullyQualifiedName;
        ModelProperties = new(commandIntermediateResult.ModelProperties);
        ModelIdPropertyName = commandIntermediateResult.ModelIdPropertyResult.PropertyName;
        ModelIdPropertyType = commandIntermediateResult.ModelIdPropertyResult.PropertyType;
        ModelIdUnderlyingPropertyType = commandIntermediateResult.ModelIdPropertyResult.UnderlyingType;
        CommandType = commandIntermediateResult.CommandType;

        RequestName = commandIntermediateResult.RequestResult.RequestName;
        RequestFullyQualifiedName = commandIntermediateResult.RequestResult.RequestFullyQualifiedName;
        ResponseName = commandIntermediateResult.ResponseResult!.ResponseName;
        ResponseFullyQualifiedName = commandIntermediateResult.ResponseResult.ResponseFullyQualifiedName;
        WithRequestMappingService = commandIntermediateResult.WithRequestMappingService;
        WithResponseMappingService = commandIntermediateResult.WithResponseMappingService;
        RequestProperties = new(commandIntermediateResult.RequestResult.PropertyNames);
        ResponseProperties = new(commandIntermediateResult.ResponseResult.PropertyNames);

        Services = new(commandIntermediateResult.Services);
        Version = commandIntermediateResult.Version;
        KeyedServices = new(commandIntermediateResult.KeyedServices);

        BusinessLogicFullyQualifiedName = commandIntermediateResult.BusinessLogicResult!.FullyQualifiedName;
        BusinessLogicDelegateName = commandIntermediateResult.BusinessLogicResult!.DelegateName;
        BusinessLogicParameters = new(commandIntermediateResult.BusinessLogicResult!.Parameters);
    }

    #endregion
}