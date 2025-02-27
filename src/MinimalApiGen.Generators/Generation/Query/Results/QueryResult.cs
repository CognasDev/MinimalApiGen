using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.Results;
using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Query.Results;

/// <summary>
/// 
/// </summary>
internal readonly record struct QueryResult : IQueryResult
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
    public OperationType OperationType { get; }

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

    /// <summary>
    /// 
    /// </summary>
    public EquatableArray<QueryParameterResult> QueryParameterResults { get; }

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
    public bool WithResponseMappingService { get; }

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
    public int ApiVersion { get; }

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
    public EquatableArray<BusinessLogicParamterResult> BusinessLogicParameters { get; }

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
        OperationType = queryIntermediateResult.OperationType;

        ResponseName = queryIntermediateResult.ResponseResult!.ResponseName;
        ResponseFullyQualifiedName = queryIntermediateResult.ResponseResult!.ResponseFullyQualifiedName;
        WithPagination = queryIntermediateResult.WithPagination;
        WithResponseMappingService = queryIntermediateResult.WithResponseMappingService;
        ResponseProperties = new(queryIntermediateResult.ResponseResult.PropertyNames);
        CachedFor = queryIntermediateResult.CachedFor;

        Services = new(queryIntermediateResult.Services);
        ApiVersion = queryIntermediateResult.Version;
        KeyedServices = new(queryIntermediateResult.KeyedServices);

        BusinessLogicFullyQualifiedName = queryIntermediateResult.BusinessLogicResult!.FullyQualifiedName;
        BusinessLogicDelegateName = queryIntermediateResult.BusinessLogicResult!.DelegateName;
        BusinessLogicParameters = new(queryIntermediateResult.BusinessLogicResult!.Parameters);

        QueryParameterResults = new(queryIntermediateResult.QueryParameterResults);
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(IResult other)
    {
        return other is QueryResult result &&
               ClassName == result.ClassName &&
               ClassNamespace == result.ClassNamespace &&
               ModelName == result.ModelName &&
               ModelPluralName == result.ModelPluralName &&
               ModelFullyQualifiedName == result.ModelFullyQualifiedName &&
               OperationType == result.OperationType &&
               ModelProperties.Equals(result.ModelProperties) &&
               ModelIdPropertyName == result.ModelIdPropertyName &&
               ModelIdPropertyType == result.ModelIdPropertyType &&
               ModelIdUnderlyingPropertyType == result.ModelIdUnderlyingPropertyType &&
               ResponseName == result.ResponseName &&
               ResponseFullyQualifiedName == result.ResponseFullyQualifiedName &&
               WithPagination == result.WithPagination &&
               WithResponseMappingService == result.WithResponseMappingService &&
               ResponseProperties.Equals(result.ResponseProperties) &&
               CachedFor == result.CachedFor &&
               Services.Equals(result.Services) &&
               ApiVersion == result.ApiVersion &&
               KeyedServices.Equals(result.KeyedServices) &&
               BusinessLogicFullyQualifiedName == result.BusinessLogicFullyQualifiedName &&
               BusinessLogicDelegateName == result.BusinessLogicDelegateName &&
               BusinessLogicParameters.Equals(result.BusinessLogicParameters) &&
               QueryParameterResults.Equals(result.QueryParameterResults);
    }

    #endregion
}