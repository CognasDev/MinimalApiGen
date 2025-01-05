using MinimalApiGen.Generators.Equality;

namespace MinimalApiGen.Generators.Query.Results;

/// <summary>
/// 
/// </summary>
internal readonly record struct QueryResult
{
    #region Field Declarations - Model Details

    /// <summary>
    /// 
    /// </summary>
    public readonly string ClassName;

    /// <summary>
    /// 
    /// </summary>
    public readonly string ClassNamespace;

    /// <summary>
    /// 
    /// </summary>
    public readonly string ModelName;

    /// <summary>
    /// 
    /// </summary>
    public readonly string ModelPluralName;

    /// <summary>
    /// 
    /// </summary>
    public readonly string ModelFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public readonly EquatableArray<string> ModelProperties;

    #endregion

    #region Field Declarations - Response Details

    /// <summary>
    /// 
    /// </summary>
    public readonly string ResponseName;

    /// <summary>
    /// 
    /// </summary>
    public readonly string ResponseFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public readonly bool WithPagination;

    /// <summary>
    /// 
    /// </summary>
    public readonly bool WithMappingService;

    /// <summary>
    /// 
    /// </summary>
    public readonly EquatableArray<string> ResponseProperties;

    /// <summary>
    /// 
    /// </summary>
    public readonly string? CachedFor;

    #endregion

    #region Field Declarations - Service Details

    /// <summary>
    /// 
    /// </summary>
    public readonly EquatableArray<string> Services;

    /// <summary>
    /// 
    /// </summary>
    public readonly int Version;

    /// <summary>
    /// 
    /// </summary>
    public readonly EquatableDictionary<string, string> KeyedServices;

    #endregion

    #region Field Declarations - Business Logic Details

    /// <summary>
    /// 
    /// </summary>
    public readonly string BusinessLogicFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public readonly string BusinessLogicDelegateName;

    /// <summary>
    /// 
    /// </summary>
    public readonly EquatableArray<string> BusinessLogicParameters;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryIntermediateResult"></param>
    public QueryResult(QueryIntermediateResult queryIntermediateResult)
    {
        ClassName = $"{queryIntermediateResult.ModelName}QueryRouteEndpointsMapper";
        ClassNamespace = queryIntermediateResult.ClassNamespace!;
        ModelName = queryIntermediateResult.ModelName;
        ModelPluralName = queryIntermediateResult.ModelPluralName;
        ModelFullyQualifiedName = queryIntermediateResult.ModelFullyQualifiedName;
        ModelProperties = new EquatableArray<string>(queryIntermediateResult.ModelProperties);

        ResponseName = queryIntermediateResult.ResponseResult!.ResponseName;
        ResponseFullyQualifiedName = queryIntermediateResult.ResponseResult!.ResponseFullyQualifiedName;
        WithPagination = queryIntermediateResult.WithPagination;
        WithMappingService = queryIntermediateResult.WithMappingService;
        ResponseProperties = new EquatableArray<string>(queryIntermediateResult.ResponseResult.PropertyNames);
        CachedFor = queryIntermediateResult.CachedFor;

        Services = new EquatableArray<string>(queryIntermediateResult.Services);
        Version = queryIntermediateResult.Version;
        KeyedServices = new EquatableDictionary<string, string>(queryIntermediateResult.KeyedServices);

        BusinessLogicFullyQualifiedName = queryIntermediateResult.BusinessLogicResult!.FullyQualifiedName;
        BusinessLogicDelegateName = queryIntermediateResult.BusinessLogicResult!.DelegateName;
        BusinessLogicParameters = new EquatableArray<string>(queryIntermediateResult.BusinessLogicResult!.Parameters);
    }

    #endregion
}