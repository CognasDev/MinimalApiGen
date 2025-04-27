using MinimalApiGen.Generators.Generation.Command.Results;
using MinimalApiGen.Generators.Generation.Query.Results;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.SourceBuilders;

namespace MinimalApiGen.Generators.Generation.Command.SourceBuilders;

/// <summary>
/// 
/// </summary>
/// <param name="commandResult"></param>
/// <param name="servicesBuilder"></param>
internal sealed class MapDeleteBuilder(ICommandResult commandResult, ServicesBuilder servicesBuilder)
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public string ClassName { get; } = commandResult.ClassName;

    /// <summary>
    /// 
    /// </summary>
    public string Namespace { get; } = commandResult.Namespace;

    /// <summary>
    /// 
    /// </summary>
    public int ApiVersion { get; } = commandResult.ApiVersion;

    /// <summary>
    /// 
    /// </summary>
    public string ModelName { get; } = commandResult.ModelName;

    /// <summary>
    /// 
    /// </summary>
    public string ModelPluralName { get; } = commandResult.ModelPluralName;

    /// <summary>
    /// 
    /// </summary>
    public string ModelPluralNameLower => ModelPluralName.ToLowerInvariant();

    /// <summary>
    /// 
    /// </summary>
    public string ModelFullyQualifiedName { get; } = commandResult.ModelFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public string ModelIdPropertyName { get; } = commandResult.ModelIdPropertyName;

    /// <summary>
    /// 
    /// </summary>
    public string ModelIdPropertyType { get; } = commandResult.ModelIdPropertyType;

    /// <summary>
    /// 
    /// </summary>
    public string? ModelIdUnderlyingPropertyType { get; } = commandResult.ModelIdUnderlyingPropertyType;

    /// <summary>
    /// 
    /// </summary>
    public string RequestName { get; } = commandResult.RequestName;

    /// <summary>
    /// 
    /// </summary>
    public string RequestFullyQualifiedName { get; } = commandResult.RequestFullyQualifiedName;

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
    public string Handler { get; } = commandResult.HandlerFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public string HandlerDelegateName { get; } = commandResult.HandlerDelegateName;

    /// <summary>
    /// 
    /// </summary>
    public string HandlerDelegateParameters { get; } = DelegateParametersBuilder.BuildForId(commandResult.HandlerParameters,
                                                                                                  commandResult.Services,
                                                                                                  commandResult.KeyedServices,
                                                                                                  commandResult.ModelIdUnderlyingPropertyType ?? commandResult.ModelIdPropertyType);

    /// <summary>
    /// 
    /// </summary>
    public string JwtAuthentication { get; } = commandResult.WithJwtAuthentication ? JwtAuthenticationBuilder.Build() : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string AuthenticationRole { get; } = commandResult.WithJwtAuthentication ? JwtAuthenticationBuilder.BuildRole(commandResult.AuthenticationRole) : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string AuthenticationNamespace { get; } = commandResult.WithJwtAuthentication ? JwtAuthenticationBuilder.BuildUsings(commandResult.AuthenticationRole) : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string EndpointFilter { get; } = !string.IsNullOrWhiteSpace(commandResult.FilterFullyQualifiedName) ? AddEndpointFilterBuilder.Build(commandResult.FilterFullyQualifiedName) : string.Empty;

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
using {RequestName} = {RequestFullyQualifiedName};
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
    public virtual RouteHandlerBuilder MapDeleteV{ApiVersion}(IEndpointRouteBuilder endpointRouteBuilder)
    {{
        return endpointRouteBuilder.MapDelete
        (
            ""/{ModelPluralNameLower}/{{id}}"",{AuthenticationRole}
            async Task<Results<NoContent, BadRequest>>
            (
                CancellationToken cancellationToken,
                [FromBody] {RequestName} request,
                [FromRoute] {ModelIdUnderlyingPropertyType ?? ModelIdPropertyType} id,
                [FromServices] {Handler} handler
            ) =>
            {{
                ArgumentNullException.ThrowIfNull(handler, nameof(handler));
                ArgumentNullException.ThrowIfNull(request, nameof(request));
                await handler.{HandlerDelegateName}({HandlerDelegateParameters}).ConfigureAwait(false);
                return TypedResults.NoContent();
            }}
        )
        .WithName(""{RouteNameFactory.Delete(ModelPluralName, ApiVersion)}"")
        .WithTags(""{ModelPluralNameLower}"")
        .WithOpenApi(operation => new(operation) {{ Summary = ""Deletes {ModelName.WithIndefiniteArticle()} via the id."" }})
        .MapToApiVersion({ApiVersion})
        .Accepts<{RequestName}>(MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status204NoContent)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json){JwtAuthentication}{EndpointFilter};
     }}
}}";

    #endregion
}