using MinimalApiGen.Generators.Equality;
using System;

namespace MinimalApiGen.Generators.Generation.Shared.Results;

/// <summary>
/// 
/// </summary>
internal interface IResult : IEquatable<IResult>
{
    #region Property Declarations - Model Details

    /// <summary>
    /// 
    /// </summary>
    string ClassName { get; }

    /// <summary>
    /// 
    /// </summary>
    string ClassNamespace { get; }

    /// <summary>
    /// 
    /// </summary>
    string ModelName { get; }

    /// <summary>
    /// 
    /// </summary>
    string ModelPluralName { get; }

    /// <summary>
    /// 
    /// </summary>
    string ModelFullyQualifiedName { get; }

    /// <summary>
    /// 
    /// </summary>
    OperationType OperationType { get; }

    /// <summary>
    /// 
    /// </summary>
    EquatableArray<string> ModelProperties { get; }

    /// <summary>
    /// 
    /// </summary>
    string ModelIdPropertyName { get; }

    /// <summary>
    /// 
    /// </summary>
    string ModelIdPropertyType { get; }

    /// <summary>
    /// 
    /// </summary>
    string? ModelIdUnderlyingPropertyType { get; }

    #endregion

    #region Property Declarations - Response Details

    /// <summary>
    /// 
    /// </summary>
    string? ResponseName { get; }

    /// <summary>
    /// 
    /// </summary>
    string? ResponseFullyQualifiedName { get; }

    /// <summary>
    /// 
    /// </summary>
    EquatableArray<string> ResponseProperties { get; }

    #endregion

    #region Property Declarations - Service Details

    /// <summary>
    /// 
    /// </summary>
    EquatableArray<string> Services { get; }

    /// <summary>
    /// 
    /// </summary>
    int ApiVersion { get; }

    /// <summary>
    /// 
    /// </summary>
    EquatableDictionary<string, string> KeyedServices { get; }

    /// <summary>
    /// 
    /// </summary>
    bool WithJwtAuthentication { get; }

    #endregion

    #region Property Declarations - Business Logic Details

    /// <summary>
    /// 
    /// </summary>
    string BusinessLogicFullyQualifiedName { get; }

    /// <summary>
    /// 
    /// </summary>
    string BusinessLogicDelegateName { get; }

    /// <summary>
    /// 
    /// </summary>
    EquatableArray<BusinessLogicParamterResult> BusinessLogicParameters { get; }

    #endregion
}