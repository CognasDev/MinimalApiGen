namespace MinimalApiGen.Generators.Query.SourceBuilders;

/// <summary>
/// 
/// </summary>
/// <param name="classNamespace"></param>
/// <param name="apiVersion"></param>
/// <param name="modelName"></param>
/// <param name="modelPluralName"></param>
/// <param name="modelFullyQualifiedName"></param>
/// <param name="responseName"></param>
/// <param name="responseFullyQualifiedName"></param>
public sealed class MapGetByIdBuilder(string classNamespace,
                                      int apiVersion,
                                      string modelName,
                                      string modelPluralName,
                                      string modelFullyQualifiedName,
                                      string responseName,
                                      string responseFullyQualifiedName)
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public string ClassNamespace { get; } = classNamespace;

    /// <summary>
    /// 
    /// </summary>
    public int ApiVersion { get; } = apiVersion;

    /// <summary>
    /// 
    /// </summary>
    public string ModelName { get; } = modelName;

    /// <summary>
    /// 
    /// </summary>
    public string ModelPluralName { get; } = modelPluralName;

    /// <summary>
    /// 
    /// </summary>
    public string ModelPluralNameLower => ModelPluralName.ToLowerInvariant();

    /// <summary>
    /// 
    /// </summary>
    public string ModelFullyQualifiedName { get; } = modelFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public string ResponseName { get; } = responseName;

    /// <summary>
    /// 
    /// </summary>
    public string ResponseFullyQualifiedName { get; } = responseFullyQualifiedName;

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    public string Build() =>
$@"using MinimalApiGen.Generators.Abstractions.Mapping;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

using {ModelName} = {ModelFullyQualifiedName};
using {ResponseName} = {ResponseFullyQualifiedName};

namespace {ClassNamespace};

/// <summary>
/// 
/// </summary>
public partial class {ModelName}QueryApi
{{
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""endpointRouteBuilder""></param>
    public virtual RouteHandlerBuilder MapGetByIdV{ApiVersion}(IEndpointRouteBuilder endpointRouteBuilder)
    {{
        return endpointRouteBuilder.MapGet
        (
            ""/{ModelPluralNameLower}/{{id}}"",
            async
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromServices] IMappingService<{ModelName}, {ResponseName}> mappingService
            ) =>
            {{
                cancellationToken.ThrowIfCancellationRequested();
            }}
        )
        .WithName(""Get{ModelPluralName}ByIdV{ApiVersion}"")
        .WithTags(""{ModelPluralNameLower}"")
        .WithOpenApi(operation => new(operation) {{ Summary = ""Gets a single {ModelName} mapped to a {ResponseName} response."" }})
        .MapToApiVersion({ApiVersion})
        .Produces<{ResponseName}>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status404NotFound, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }}
}}";

    #endregion
}