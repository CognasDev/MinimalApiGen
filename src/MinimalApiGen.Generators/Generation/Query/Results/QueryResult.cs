using MinimalApiGen.Generators.Equality;

namespace MinimalApiGen.Generators.Generation.Query.Results;

/// <summary>
/// 
/// </summary>
internal readonly record struct QueryResult
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
    public QueryType QueryType { get; }

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
    public bool WithPagination { get; }

    /// <summary>
    /// 
    /// </summary>
    public bool WithMappingService { get; }

    /// <summary>
    /// 
    /// </summary>
    public EquatableArray<string> ResponseProperties { get; }

    /// <summary>
    /// 
    /// </summary>
    public string? CachedFor { get; }

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
    /// <param name="queryIntermediateResult"></param>
    public QueryResult(QueryIntermediateResult queryIntermediateResult)
    {
        ClassName = $"{queryIntermediateResult.ModelName}QueryRouteEndpointsMapper";
        ClassNamespace = queryIntermediateResult.QueryNamespace!;
        ModelName = queryIntermediateResult.ModelName;
        ModelPluralName = queryIntermediateResult.ModelPluralName;
        ModelFullyQualifiedName = queryIntermediateResult.ModelFullyQualifiedName;
        ModelProperties = new(queryIntermediateResult.ModelProperties);
        ModelIdPropertyName = queryIntermediateResult.ModelIdPropertyResult.PropertyName;
        ModelIdPropertyType = queryIntermediateResult.ModelIdPropertyResult.PropertyType;
        ModelIdUnderlyingPropertyType = queryIntermediateResult.ModelIdPropertyResult.UnderlyingType;
        QueryType = queryIntermediateResult.QueryType;

        ResponseName = queryIntermediateResult.ResponseResult!.ResponseName;
        ResponseFullyQualifiedName = queryIntermediateResult.ResponseResult!.ResponseFullyQualifiedName;
        WithPagination = queryIntermediateResult.WithPagination;
        WithMappingService = queryIntermediateResult.WithMappingService;
        ResponseProperties = new(queryIntermediateResult.ResponseResult.PropertyNames);
        CachedFor = queryIntermediateResult.CachedFor;

        Services = new(queryIntermediateResult.Services);
        Version = queryIntermediateResult.Version;
        KeyedServices = new(queryIntermediateResult.KeyedServices);

        BusinessLogicFullyQualifiedName = queryIntermediateResult.BusinessLogicResult!.FullyQualifiedName;
        BusinessLogicDelegateName = queryIntermediateResult.BusinessLogicResult!.DelegateName;
        BusinessLogicParameters = new(queryIntermediateResult.BusinessLogicResult!.Parameters);
    }

    #endregion
}