using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Query.Results;
using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace MinimalApiGen.Generators.Generation.Query.SourceBuilders;

/// <summary>
/// 
/// </summary>
/// <param name="queryResult"></param>
/// <param name="apiVersion"></param>
/// <param name="servicesBuilder"></param>
/// <param name="cachedForBuilder"></param>
internal sealed class MapGetByIdBuilder(QueryResult queryResult, int apiVersion, ServicesBuilder servicesBuilder, CachedForBuilder cachedForBuilder)
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public string ClassName { get; } = queryResult.ClassName;

    /// <summary>
    /// 
    /// </summary>
    public string ClassNamespace { get; } = queryResult.ClassNamespace;

    /// <summary>
    /// 
    /// </summary>
    public int ApiVersion { get; } = apiVersion;

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
    public string ResponseName { get; } = queryResult.ResponseName;

    /// <summary>
    /// 
    /// </summary>
    public string ResponseFullyQualifiedName { get; } = queryResult.ResponseFullyQualifiedName;

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
    public string BusinessLogic { get; } = queryResult.BusinessLogicFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public string BusinessLogicDelegateName { get; } = queryResult.BusinessLogicDelegateName;

    /// <summary>
    /// 
    /// </summary>
    public string BusinessLogicDelegateParameters { get; } = BuildDelegateParameters(queryResult.BusinessLogicParameters,
                                                                                     queryResult.Services,
                                                                                     queryResult.KeyedServices);

    /// <summary>
    /// 
    /// </summary>
    public string CachedFor { get; } = cachedForBuilder.Build(queryResult.CachedFor);

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    public string Build() =>
$@"using MinimalApiGen.Framework.Mapping;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

using {ModelName} = {ModelFullyQualifiedName};
using {ResponseName} = {ResponseFullyQualifiedName};

namespace {ClassNamespace};

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
            ""/{ModelPluralNameLower}/{{id}}"",
            async
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromServices] {BusinessLogic} businessLogic,
                [FromServices] IMappingService<{ModelName}, {ResponseName}> mappingService{FromServices}{FromKeyedServices}
            ) =>
            {{
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));

                {ModelName}? model = await businessLogic.{BusinessLogicDelegateName}({BusinessLogicDelegateParameters}).ConfigureAwait(false);

                if (model is null)
                {{
                    return Results.NotFound();
                }}

                {ResponseName} response = mappingService.Map(model);
                return Results.Ok(response);
            }}
        )
        .WithName(""GetById{ModelPluralName}V{ApiVersion}"")
        .WithTags(""{ModelPluralNameLower}"")
        .WithOpenApi(operation => new(operation) {{ Summary = ""Gets a single model of {ModelName} by the id, mapped to a {ResponseName} response."" }})
        .MapToApiVersion({ApiVersion})
        .Produces<IEnumerable<{ResponseName}>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status404NotFound)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json){CachedFor};
     }}
}}";

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="businessLogicParameters"></param>
    /// <param name="services"></param>
    /// <param name="keyedServices"></param>
    /// <returns></returns>
    private static string BuildDelegateParameters(EquatableArray<string> businessLogicParameters,
                                                  EquatableArray<string> services,
                                                  EquatableDictionary<string, string> keyedServices)
    {
        ReadOnlySpan<string> keys = keyedServices.KeysAsSpan();
        ReadOnlySpan<string> values = keyedServices.ValuesAsSpan();
        ReadOnlySpan<string> businessLogicParametersSpan = businessLogicParameters.AsSpan();
        StringBuilder stringBuilder = new();

        foreach (string parameter in businessLogicParametersSpan)
        {
            if (services.Contains(parameter))
            {
                string serviceName = parameter.Split('.').Last();
                string serviceNameCamelCase = JsonNamingPolicy.CamelCase.ConvertName(serviceName);
                stringBuilder.Append(serviceNameCamelCase);
                stringBuilder.Append(", ");
            }
            else if (values.IndexOf(parameter) is int index && index != -1)
            {
                string keyedServiceNameCamelCase = JsonNamingPolicy.CamelCase.ConvertName(keys[index]);
                stringBuilder.Append(keyedServiceNameCamelCase);
                stringBuilder.Append(", ");
            }
            else if (parameter == "int")
            {
                stringBuilder.Append("id, ");
            }
            else if (parameter == typeof(CancellationToken).FullName)
            {
                stringBuilder.Append("cancellationToken, ");
            }
        }

        stringBuilder.Length -= 2;
        string delegateParameters = stringBuilder.ToString();
        return delegateParameters;
    }

    #endregion
}