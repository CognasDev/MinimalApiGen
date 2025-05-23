﻿using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.Results;

namespace MinimalApiGen.Generators.Generation.Command.Results;

/// <summary>
/// 
/// </summary>
internal readonly record struct CommandResult : ICommandResult
{
    #region Property Declarations - Model Details

    /// <summary>
    /// 
    /// </summary>
    public string ClassName { get; }

    /// <summary>
    /// 
    /// </summary>
    public string Namespace { get; }

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

    /// <summary>
    /// 
    /// </summary>
    public bool WithFluentValidation { get; }

    #endregion

    #region Property Declarations - Response Details

    /// <summary>
    /// 
    /// </summary>
    public string? ResponseName { get; }

    /// <summary>
    /// 
    /// </summary>
    public string? ResponseFullyQualifiedName { get; }

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
    public int ApiVersion { get; }

    /// <summary>
    /// 
    /// </summary>
    public EquatableDictionary<string, string> KeyedServices { get; }

    /// <summary>
    /// 
    /// </summary>
    public bool WithJwtAuthentication { get; }

    /// <summary>
    /// 
    /// </summary>
    public string AuthenticationRole { get; }

    /// <summary>
    /// 
    /// </summary>
    public string FilterName { get; }

    /// <summary>
    /// 
    /// </summary>
    public string FilterFullyQualifiedName { get; }

    #endregion

    #region Property Declarations - Business Logic Details

    /// <summary>
    /// 
    /// </summary>
    public string HandlerFullyQualifiedName { get; }

    /// <summary>
    /// 
    /// </summary>
    public string HandlerDelegateName { get; }

    /// <summary>
    /// 
    /// </summary>
    public EquatableArray<HandlerParamterResult> HandlerParameters { get; }

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commandIntermediateResult"></param>
    public CommandResult(CommandIntermediateResult commandIntermediateResult)
    {
        ClassName = $"{commandIntermediateResult.ModelName}CommandRouteEndpointsMapper";
        Namespace = commandIntermediateResult.Namespace!;
        ModelName = commandIntermediateResult.ModelName;
        ModelPluralName = commandIntermediateResult.ModelPluralName;
        ModelFullyQualifiedName = commandIntermediateResult.ModelFullyQualifiedName;
        ModelProperties = new(commandIntermediateResult.ModelProperties);
        ModelIdPropertyName = commandIntermediateResult.ModelIdPropertyResult.PropertyName;
        ModelIdPropertyType = commandIntermediateResult.ModelIdPropertyResult.PropertyType;
        ModelIdUnderlyingPropertyType = commandIntermediateResult.ModelIdPropertyResult.UnderlyingType;
        OperationType = commandIntermediateResult.OperationType;

        RequestName = commandIntermediateResult.RequestResult.RequestName;
        WithFluentValidation = commandIntermediateResult.WithFluentValidation;
        RequestFullyQualifiedName = commandIntermediateResult.RequestResult.RequestFullyQualifiedName;
        ResponseName = commandIntermediateResult.ResponseResult?.ResponseName;
        ResponseFullyQualifiedName = commandIntermediateResult.ResponseResult?.ResponseFullyQualifiedName;
        WithRequestMappingService = commandIntermediateResult.WithRequestMappingService;
        WithResponseMappingService = commandIntermediateResult.WithResponseMappingService;
        RequestProperties = new(commandIntermediateResult.RequestResult.PropertyNames);
        ResponseProperties = commandIntermediateResult.ResponseResult is not null ? new(commandIntermediateResult.ResponseResult.PropertyNames) : [];

        Services = new(commandIntermediateResult.Services);
        ApiVersion = commandIntermediateResult.Version;
        KeyedServices = new(commandIntermediateResult.KeyedServices);

        HandlerFullyQualifiedName = commandIntermediateResult.HandlerResult!.FullyQualifiedName;
        HandlerDelegateName = commandIntermediateResult.HandlerResult!.DelegateName;
        HandlerParameters = new(commandIntermediateResult.HandlerResult!.Parameters);

        WithJwtAuthentication = commandIntermediateResult.WithJwtAuthentication;
        AuthenticationRole = commandIntermediateResult.AuthenticationRole ?? string.Empty;

        FilterName = commandIntermediateResult.AddEndpointFilterResult?.FilterName ?? string.Empty;
        FilterFullyQualifiedName = commandIntermediateResult.AddEndpointFilterResult?.FilterFullyQualifiedName ?? string.Empty;
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
        return other is CommandResult result &&
               ClassName == result.ClassName &&
               Namespace == result.Namespace &&
               ModelName == result.ModelName &&
               ModelPluralName == result.ModelPluralName &&
               ModelFullyQualifiedName == result.ModelFullyQualifiedName &&
               OperationType == result.OperationType &&
               ModelProperties == result.ModelProperties &&
               ModelIdPropertyName == result.ModelIdPropertyName &&
               ModelIdPropertyType == result.ModelIdPropertyType &&
               ModelIdUnderlyingPropertyType == result.ModelIdUnderlyingPropertyType &&
               RequestName == result.RequestName &&
               RequestFullyQualifiedName == result.RequestFullyQualifiedName &&
               WithRequestMappingService == result.WithRequestMappingService &&
               RequestProperties == result.RequestProperties &&
               ResponseName == result.ResponseName &&
               ResponseFullyQualifiedName == result.ResponseFullyQualifiedName &&
               WithResponseMappingService == result.WithResponseMappingService &&
               ResponseProperties == result.ResponseProperties &&
               Services == result.Services &&
               ApiVersion == result.ApiVersion &&
               KeyedServices == result.KeyedServices &&
               HandlerFullyQualifiedName == result.HandlerFullyQualifiedName &&
               HandlerDelegateName == result.HandlerDelegateName &&
               HandlerParameters == result.HandlerParameters &&
               WithFluentValidation == result.WithFluentValidation &&
               WithJwtAuthentication == result.WithJwtAuthentication &&
               AuthenticationRole == result.AuthenticationRole &&
               FilterName == result.FilterName &&
               FilterFullyQualifiedName == result.FilterFullyQualifiedName;
    }

    #endregion
}