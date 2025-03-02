using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Query.Results;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.Results;
using MinimalApiGen.Generators.Generation.Shared.SourceBuilders;
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
/// <param name="servicesBuilder"></param>
internal sealed class MapGetBuilder(IQueryResult queryResult, ServicesBuilder servicesBuilder)
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
    public string PaginationCode { get; } = queryResult.WithPagination ? PaginationBuilder.Build(queryResult.ResponseName!) : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string PaginationServiceAndQuery { get; } = queryResult.WithPagination ? PaginationBuilder.PaginationServiceAndQuery : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string PaginationUsings { get; } = queryResult.WithPagination ? PaginationBuilder.PaginationUsings : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string PaginationComment { get; } = queryResult.WithPagination ? PaginationBuilder.PaginationComment : string.Empty;

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
                                                                                     queryResult.KeyedServices,
                                                                                     queryResult.QueryParameterResults);

    /// <summary>
    /// 
    /// </summary>
    public string QueryParameters { get; } = BuildQueryParameters(queryResult.QueryParameterResults);

    /// <summary>
    /// 
    /// </summary>
    public string CachedFor { get; } = CachedForBuilder.Build(queryResult.CachedFor);

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    public string Build() =>
$@"using MinimalApiGen.Framework.Mapping;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
{PaginationUsings}
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
    public virtual RouteHandlerBuilder MapGetV{ApiVersion}(IEndpointRouteBuilder endpointRouteBuilder)
    {{
        return endpointRouteBuilder.MapGet
        (
            ""/{ModelPluralNameLower}"",
            (
                CancellationToken cancellationToken,{QueryParameters}
                [FromServices] {BusinessLogic} businessLogic,
                [FromServices] IMappingService<{ModelName}, {ResponseName}> mappingService{FromServices}{FromKeyedServices}{PaginationServiceAndQuery}
            ) =>
            {{
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));
                async IAsyncEnumerable<{ResponseName}> {ResponseName}StreamAsync()
                {{
                    IEnumerable<{ModelName}> models = await businessLogic.{BusinessLogicDelegateName}({BusinessLogicDelegateParameters}).ConfigureAwait(false);
                    IEnumerable<{ResponseName}> responses = mappingService.Map(models);
{PaginationCode}
                    foreach ({ResponseName} response in responses)
                    {{
                        cancellationToken.ThrowIfCancellationRequested();
                        yield return response;
                    }}
                }}
                return {ResponseName}StreamAsync();   
            }}
        )
        .WithName(""{RouteNameFactory.Get(ModelPluralName, ApiVersion)}"")
        .WithTags(""{ModelPluralNameLower}"")
        .WithOpenApi(operation => new(operation) {{ Summary = ""Gets a collection of {ModelPluralName} mapped to {ResponseName} responses.{PaginationComment}"" }})
        .MapToApiVersion({ApiVersion})
        .Produces<IEnumerable<{ResponseName}>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
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
    /// <param name="queryParameters"></param>
    /// <returns></returns>
    private static string BuildDelegateParameters(EquatableArray<BusinessLogicParamterResult> businessLogicParameters,
                                                  EquatableArray<string> services,
                                                  EquatableDictionary<string, string> keyedServices,
                                                  EquatableArray<QueryParameterResult> queryParameters)
    {
        if (businessLogicParameters.Count == 0)
        {
            return string.Empty;
        }

        ReadOnlySpan<string> keys = keyedServices.KeysAsSpan();
        ReadOnlySpan<string> values = keyedServices.ValuesAsSpan();
        ReadOnlySpan<BusinessLogicParamterResult> businessLogicParametersSpan = businessLogicParameters.AsSpan();
        StringBuilder stringBuilder = new();

        foreach (BusinessLogicParamterResult parameter in businessLogicParametersSpan)
        {
            string parameterType = parameter.Type;
            if (queryParameters.SingleOrDefault(queryParameter => queryParameter.Name == parameter.Name) is QueryParameterResult queryParameterResult)
            {
                stringBuilder.Append(queryParameterResult.Name);
                stringBuilder.Append(", ");
            }
            else if (services.Contains(parameterType))
            {
                string serviceName = parameterType.Split('.').Last();
                string serviceNameCamelCase = JsonNamingPolicy.CamelCase.ConvertName(serviceName);
                stringBuilder.Append(serviceNameCamelCase);
                stringBuilder.Append(", ");
            }
            else if (values.IndexOf(parameterType) is int index && index != -1)
            {
                string keyedServiceNameCamelCase = JsonNamingPolicy.CamelCase.ConvertName(keys[index]);
                stringBuilder.Append(keyedServiceNameCamelCase);
                stringBuilder.Append(", ");
            }
            else if (parameterType == typeof(CancellationToken).FullName)
            {
                stringBuilder.Append("cancellationToken, ");
            }
        }

        stringBuilder.Length -= 2;
        string delegateParameters = stringBuilder.ToString();
        return delegateParameters;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryParameterResults"></param>
    /// <returns></returns>
    private static string BuildQueryParameters(EquatableArray<QueryParameterResult> queryParameterResults)
    {
        if (queryParameterResults.Count == 0)
        {
            return string.Empty;
        }
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine();
        foreach (QueryParameterResult queryParameterResult in queryParameterResults)
        {
            stringBuilder.Append("\t\t\t\t[FromQuery] ");
            stringBuilder.Append(queryParameterResult.Type);
            if (!queryParameterResult.Type.EndsWith("?"))
            {
                stringBuilder.Append("?");
            }
            stringBuilder.Append(" ");
            stringBuilder.Append(queryParameterResult.Name);
            stringBuilder.AppendLine(",");
        }
        stringBuilder.Length -= 1;
        string queryParameters = stringBuilder.ToString();
        return queryParameters;
    }

    #endregion
}
