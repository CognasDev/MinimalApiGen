﻿using MinimalApiGen.Generators.Generation.Query.Results;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.Results;
using MinimalApiGen.Generators.Generation.Shared.SourceBuilders;
using System;

namespace MinimalApiGen.Generators.Generation.Query.SourceBuilders;

/// <summary>
/// 
/// </summary>
/// <param name="queryResult"></param>
/// <param name="servicesBuilder"></param>
internal sealed class MapGetByIdBuilder(IQueryResult queryResult, ServicesBuilder servicesBuilder)
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public string ClassName { get; } = queryResult.ClassName;

    /// <summary>
    /// 
    /// </summary>
    public string Namespace { get; } = queryResult.Namespace;

    /// <summary>
    /// 
    /// </summary>
    public int ApiVersion { get; } = queryResult.ApiVersion;

    /// <summary>
    /// 
    /// </summary>
    public string ModelName { get; } = queryResult.ModelName;

    /// <summary>
    /// 
    /// </summary>
    public string ModelPluralName { get; } = queryResult.ModelPluralName;

    /// <summary>
    /// 
    /// </summary>
    public string ModelPluralNameLower => ModelPluralName.ToLowerInvariant();

    /// <summary>
    /// 
    /// </summary>
    public string ModelFullyQualifiedName { get; } = queryResult.ModelFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public string ModelIdPropertyName { get; } = queryResult.ModelIdPropertyName;

    /// <summary>
    /// 
    /// </summary>
    public string ModelIdPropertyType { get; } = queryResult.ModelIdPropertyType;

    /// <summary>
    /// 
    /// </summary>
    public string? ModelIdUnderlyingPropertyType { get; } = queryResult.ModelIdUnderlyingPropertyType;

    /// <summary>
    /// 
    /// </summary>
    public string ResponseName { get; } = !string.IsNullOrWhiteSpace(queryResult.ResponseName) ? queryResult.ResponseName! : throw new ArgumentNullException(nameof(IResult.ResponseName));

    /// <summary>
    /// 
    /// </summary>
    public string ResponseFullyQualifiedName { get; } = !string.IsNullOrWhiteSpace(queryResult.ResponseFullyQualifiedName) ? queryResult.ResponseFullyQualifiedName! : throw new ArgumentNullException(nameof(IResult.ResponseFullyQualifiedName));


    /// <summary>
    /// 
    /// </summary>
    public string FromServices { get; } = servicesBuilder.FromServices;

    /// <summary>
    /// 
    /// </summary>
    public string FromKeyedServices { get; } = servicesBuilder.FromKeyedServices;

    /// <summary>
    /// 
    /// </summary>
    public string ServiceNames { get; } = servicesBuilder.ServiceNames;

    /// <summary>
    /// 
    /// </summary>
    public string Handler { get; } = queryResult.HandlerFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public string HandlerDelegateName { get; } = queryResult.HandlerDelegateName;

    /// <summary>
    /// 
    /// </summary>
    public string HandlerDelegateParameters { get; } = DelegateParametersBuilder.BuildForId(queryResult.HandlerParameters,
                                                                                            queryResult.Services,
                                                                                            queryResult.KeyedServices,
                                                                                            queryResult.ModelIdUnderlyingPropertyType ?? queryResult.ModelIdPropertyType);

    /// <summary>
    /// 
    /// </summary>
    public string CachedFor { get; } = CachedForBuilder.Build(queryResult.CachedFor);

    /// <summary>
    /// 
    /// </summary>
    public string JwtAuthentication { get; } = queryResult.WithJwtAuthentication ? JwtAuthenticationBuilder.Build() : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string AuthenticationRole { get; } = queryResult.WithJwtAuthentication ? JwtAuthenticationBuilder.BuildRole(queryResult.AuthenticationRole) : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string AuthenticationNamespace { get; } = queryResult.WithJwtAuthentication ? JwtAuthenticationBuilder.BuildUsings(queryResult.AuthenticationRole) : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string EndpointFilter { get; } = !string.IsNullOrWhiteSpace(queryResult.FilterFullyQualifiedName) ? AddEndpointFilterBuilder.Build(queryResult.FilterFullyQualifiedName) : string.Empty;

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    public string Build() =>
$@"using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;
{AuthenticationNamespace}
using {ModelName} = {ModelFullyQualifiedName};
using {ResponseName} = {ResponseFullyQualifiedName};

namespace {Namespace};

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class {ClassName}
{{
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""endpointRouteBuilder""></param>
    public virtual RouteHandlerBuilder MapGetByIdV{ApiVersion}(IEndpointRouteBuilder endpointRouteBuilder)
    {{
        return endpointRouteBuilder.MapGet
        (
            ""/{ModelPluralNameLower}/{{id}}"",{AuthenticationRole}
            async Task<Results<Ok<{ResponseName}>, NotFound>>
            (
                CancellationToken cancellationToken,
                [FromRoute] {ModelIdUnderlyingPropertyType ?? ModelIdPropertyType} id,
                [FromServices] {Handler} handler,
                [FromServices] IMappingService<{ModelName}, {ResponseName}> mappingService{FromServices}{FromKeyedServices}
            ) =>
            {{
                ArgumentNullException.ThrowIfNull(handler, nameof(handler));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));

                {ModelName}? model = await handler.{HandlerDelegateName}({HandlerDelegateParameters}).ConfigureAwait(false);

                if (model is null)
                {{
                    return TypedResults.NotFound();
                }}

                {ResponseName} response = mappingService.Map(model);
                return TypedResults.Ok(response);
            }}
        )
        .WithName(""{RouteNameFactory.GetById(ModelPluralName, ApiVersion)}"")
        .WithTags(""{ModelPluralNameLower}"")
        .WithOpenApi(operation => new(operation) {{ Summary = ""Gets a single model of {ModelName.WithIndefiniteArticle()} by the id, mapped to {ResponseName.WithIndefiniteArticle()} response."" }})
        .MapToApiVersion({ApiVersion})
        .Produces<{ResponseName}>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status404NotFound)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json){CachedFor}{JwtAuthentication}{EndpointFilter};
     }}
}}";

    #endregion
}