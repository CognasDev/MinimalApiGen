using MinimalApiGen.Generators.Equality;

namespace MinimalApiGen.Generators.Query.Results;

/// <summary>
/// 
/// </summary>
/// <param name="queryIntermediateResult"></param>
internal readonly struct QueryResult(QueryIntermediateResult queryIntermediateResult)
{
    #region Field Declarations - Model Details

    /// <summary>
    /// 
    /// </summary>
    public readonly string ClassName = $"{queryIntermediateResult.ModelName}QueryRouteEndpointsMapper";

    /// <summary>
    /// 
    /// </summary>
    public readonly string ClassNamespace = queryIntermediateResult.ClassNamespace!;

    /// <summary>
    /// 
    /// </summary>
    public readonly string ModelName = queryIntermediateResult.ModelName;

    /// <summary>
    /// 
    /// </summary>
    public readonly string ModelPluralName = queryIntermediateResult.ModelPluralName;

    /// <summary>
    /// 
    /// </summary>
    public readonly string ModelFullyQualifiedName = queryIntermediateResult.ModelFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public readonly EquatableArray<string> ModelProperties = new(queryIntermediateResult.ModelProperties);

    #endregion

    #region Field Declarations - Response Details

    /// <summary>
    /// 
    /// </summary>
    public readonly string ResponseName = queryIntermediateResult.ResponseResult!.ResponseName;

    /// <summary>
    /// 
    /// </summary>
    public readonly string ResponseFullyQualifiedName = queryIntermediateResult.ResponseResult!.ResponseFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public readonly bool WithPagination = queryIntermediateResult.WithPagination;

    /// <summary>
    /// 
    /// </summary>
    public readonly bool WithMappingService = queryIntermediateResult.WithMappingService;

    /// <summary>
    /// 
    /// </summary>
    public readonly EquatableArray<string> ResponseProperties = new(queryIntermediateResult.ResponseResult.PropertyNames);

    /// <summary>
    /// 
    /// </summary>
    public readonly string? CachedFor = queryIntermediateResult.CachedFor;

    #endregion

    #region Field Declarations - Service Details

    /// <summary>
    /// 
    /// </summary>
    public readonly EquatableArray<string> Services = new(queryIntermediateResult.Services);

    /// <summary>
    /// 
    /// </summary>
    public readonly int Version = queryIntermediateResult.Version;

    /// <summary>
    /// 
    /// </summary>
    public readonly EquatableDictionary<string, string> KeyedServices = new(queryIntermediateResult.KeyedServices);

    #endregion

    #region Field Declarations - Business Logic Details

    /// <summary>
    /// 
    /// </summary>
    public readonly string BusinessLogicFullyQualifiedName = queryIntermediateResult.BusinessLogicResult!.FullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public readonly string BusinessLogicDelegateName = queryIntermediateResult.BusinessLogicResult!.DelegateName;

    /// <summary>
    /// 
    /// </summary>
    public readonly EquatableArray<string> BusinessLogicParameters = new(queryIntermediateResult.BusinessLogicResult!.Parameters);

    #endregion
}